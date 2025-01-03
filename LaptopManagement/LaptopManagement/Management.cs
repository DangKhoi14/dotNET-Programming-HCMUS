using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Data.SqlClient;

using LaptopManagement.Models;
using Microsoft.Data.SqlClient;

namespace LaptopManagement
{
    public partial class Management : Form
    {
        internal List<Laptop> LtpList = new List<Laptop>();
        // loadData = 0 (chýa coì dýÞ liêòu)
        // loadData = 1 (coì dýÞ liêòu týÌ excel)
        // loadData = 2 (coì dýÞ liêòu týÌ SQL server)
        public int loadData = 0;
        static string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string ExcelFilePath = ProjectPath + "\\data\\LaptopList.xlsx";
        string connectionString =
            "Data Source=MSI\\SQLEXPRESS;Initial Catalog=LaptopDB;Integrated Security=SSPI;TrustServerCertificate=True;";
        int CurrentLaptopIndex = -1;
        DataTable datatable;
        BindingSource binding = new BindingSource();
        string subPath;

        public Management()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, EventArgs e)
        {

        }

        private void ColumnPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private int ReadDataFromFile(List<Laptop> DataList, string FilePath, int colCount)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int numLaptop = 0;

            for (int i = 2; i <= rowCount; i++) // Start from row 2, skipping header
            {
                // Check if the row is empty
                bool isEmptyRow = true;
                for (int j = 1; j <= colCount; j++)
                {
                    var cellValue = xlRange.Cells[i, j]?.Value2;
                    if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                    {
                        isEmptyRow = false;
                        break;
                    }
                }

                if (isEmptyRow)
                {
                    continue; // Skip empty rows
                }

                try
                {
                    Guid LaptopID = Guid.Empty;
                    string LaptopName = "";
                    string LaptopType = "";
                    DateTime ProductDate = DateTime.MinValue;
                    string Processor = "";
                    string HDD = "";
                    string RAM = "";
                    int Price = 0;
                    string ImageName = "";

                    for (int j = 1; j <= colCount; j++)
                    {
                        var cellValue = xlRange.Cells[i, j]?.Value2;

                        switch (j)
                        {
                            case 1:
                                LaptopID = Guid.TryParse(cellValue?.ToString(), out Guid parsedGuid) ? parsedGuid : Guid.Empty;
                                break;
                            case 2:
                                LaptopName = cellValue?.ToString() ?? "";
                                break;
                            case 3:
                                LaptopType = cellValue?.ToString() ?? "";
                                break;
                            case 4:
                                if (double.TryParse(cellValue?.ToString(), out double excelDate))
                                {
                                    ProductDate = DateTime.FromOADate(excelDate);
                                }
                                break;
                            case 5:
                                Processor = cellValue?.ToString() ?? "";
                                break;
                            case 6:
                                HDD = cellValue?.ToString() ?? "";
                                break;
                            case 7:
                                RAM = cellValue?.ToString() ?? "";
                                break;
                            case 8:
                                Price = int.TryParse(cellValue?.ToString(), out int parsedPrice) ? parsedPrice : 0;
                                break;
                            case 9:
                                ImageName = cellValue?.ToString() ?? "";
                                Console.WriteLine($"Row {i}, Column {j} - ImageName: {ImageName}");
                                break;
                        }
                    }

                    // Add Laptop to the list only if meaningful data exists
                    if (!string.IsNullOrEmpty(LaptopName) && !string.IsNullOrEmpty(LaptopType))
                    {
                        DataList.Add(new Laptop
                        {
                            LaptopID = LaptopID,
                            LaptopName = LaptopName,
                            LaptopType = LaptopType,
                            ProductDate = ProductDate,
                            Processor = Processor,
                            HDD = HDD,
                            RAM = RAM,
                            Price = Price,
                            ImageName = ImageName
                        });
                        numLaptop++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing row {i}: {ex.Message}");
                }
            }

            // Release Excel resources
            xlWorkbook.Close(false);
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);

            MessageBox.Show($"Load Data From Excel Finished! : {numLaptop} Records");
            return numLaptop;
        }


        private void btnLoadFromExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear existing data
                loadData = 1;
                datatable = new DataTable();
                LtpList.Clear();

                // Read data from Excel
                int colCount = 9; // Match your Excel column count
                int NumDataRow = ReadDataFromFile(LtpList, ExcelFilePath, colCount);

                if (NumDataRow > 0)
                {
                    // Reset and rebind data
                    binding.DataSource = null; // Clear existing binding
                    binding.DataSource = LtpList; // Bind new data
                    dgwLaptopList.AutoGenerateColumns = false;
                    dgwLaptopList.DataSource = binding;

                    // Force UI updates
                    if (dgwLaptopList.Rows.Count > 0)
                    {
                        dgwLaptopList.ClearSelection();
                        dgwLaptopList.Rows[0].Selected = true; // Select first row
                    }

                    // Clear picture box if needed
                    picImage.Image = null;
                }
                else
                {
                    MessageBox.Show("No data loaded from Excel.", "Load Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data from Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgwLaptopList_SelectionChanged(object sender, EventArgs e)
        {
            if (LtpList.Count == 0 || datatable.Rows.Count == 0) return;

            var CurrentLaptopIndex = dgwLaptopList.CurrentRow.Index;
            subPath = "\\data\\LaptopListImg\\";

            if (CurrentLaptopIndex >= 0 && CurrentLaptopIndex < LtpList.Count)
            {
                picImage.Image = Image.FromFile(ProjectPath + subPath + LtpList[CurrentLaptopIndex].ImageName);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row;
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                row = datatable.Rows[i];

                LtpList[i].LaptopName = row["LaptopName"].ToString();
                LtpList[i].LaptopType = row["LaptopType"].ToString();
                LtpList[i].ProductDate = DateTime.ParseExact(row["ProductDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                LtpList[i].Processor = row["Processor"].ToString();
                LtpList[i].HDD = row["HDD"].ToString();
                LtpList[i].RAM = row["RAM"].ToString();

                string StringPrice = row["Price"].ToString();
                LtpList[i].Price = Convert.ToInt32(StringPrice.Substring(0, StringPrice.IndexOf(" ")));
                LtpList[i].ImageName = LtpList[i].LaptopName + ".png";
            }

            MessageBox.Show("Finish Update");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Laptop lt = new Laptop();
            lt.LaptopName = "Not Assigned";
            lt.LaptopType = "Not Assigned";
            lt.ProductDate = DateTime.ParseExact("01/01/1900", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            lt.Processor = "Not Assigned";
            lt.HDD = "0GB";
            lt.RAM = "0GB";
            lt.Price = 0;
            LtpList.Add(lt);

            DataRow newrow;
            newrow = datatable.NewRow();
            newrow["LaptopID"] = lt.LaptopID;
            newrow["LaptopName"] = lt.LaptopName;
            newrow["LaptopType"] = lt.LaptopType;
            newrow["ProductDate"] = lt.ProductDate;
            newrow["Processor"] = lt.Processor;
            newrow["HDD"] = lt.HDD;
            newrow["RAM"] = lt.RAM;
            newrow["Price"] = lt.Price.ToString();
            newrow["ImageName"] = lt.ImageName;
            datatable.Rows.Add(newrow);
            datatable.AcceptChanges();

            MessageBox.Show("Finish Adding");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Laptop lt;
            if (CurrentLaptopIndex >= 0)
                lt = LtpList[CurrentLaptopIndex];
            else
                return;

            string question = "Do you want to delete Laptop: " + lt.LaptopName;

            DialogResult result = MessageBox.Show(question, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LtpList.RemoveAt(CurrentLaptopIndex);
                binding.RemoveAt(CurrentLaptopIndex);
            }

            MessageBox.Show("Finish Delete");
        }

        private int ReadDataFromSQLServer(List<Laptop> LtpList, string connectionString)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            int iRow = 0;
            int NumRecords = 0;

            try
            {
                cnn.Open();
                Console.WriteLine("Connection Open ! ");

                string SQLString = @"SELECT
                                        LaptopID,
                                        LaptopName,
                                        LaptopType,
                                        ProductDate = Convert(varchar(10),CONVERT(date,ProductDate,106),103),
                                        Processor,
                                        HDD,
                                        RAM,
                                        Price,
                                        ImageName
                                        FROM dbo.Laptop";

                using (var command = new SqlCommand(SQLString, cnn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LtpList.Add(new Laptop());
                            LtpList[iRow].LaptopID = reader.GetGuid(0);
                            LtpList[iRow].LaptopName = reader.GetString(1);
                            LtpList[iRow].LaptopType = reader.GetString(2);
                            LtpList[iRow].ProductDate = DateTime.ParseExact(reader.GetString(3), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            LtpList[iRow].Processor = reader.GetString(4);
                            LtpList[iRow].HDD = reader.GetString(5);
                            LtpList[iRow].RAM = reader.GetString(6);
                            LtpList[iRow].Price = reader.GetInt32(7);
                            LtpList[iRow].ImageName = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);

                            iRow = iRow + 1;
                        }
                    }
                }

                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Laptop", cnn);
                object result = cmd.ExecuteScalar();
                NumRecords = int.Parse(result.ToString());

                MessageBox.Show("Finish Load Data from SQL Server " + NumRecords.ToString() + " Records");
                cnn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Can not open connection " + ex.Message);
            }

            return NumRecords;
        }

        private void btnLoadFromSQL_Click(object sender, EventArgs e)
        {
            loadData = 2;
            datatable = new DataTable();
            LtpList.Clear();

            int NumDataRow = ReadDataFromSQLServer(LtpList, connectionString);

            var sublist = LtpList.Select(x => new
            {
                colLaptopID = x.LaptopID,
                colLaptopName = x.LaptopName,
                colLaptopType = x.LaptopType,
                colProductDate = x.ProductDate,
                colProcessor = x.Processor,
                colHDD = x.HDD,
                colRAM = x.RAM,
                colPrice = x.Price.ToString() + " USD",
                colImageName = x.ImageName,
            }).ToList();

            datatable.Columns.Add("LaptopID");
            datatable.Columns.Add("LaptopName");
            datatable.Columns.Add("LaptopType");
            datatable.Columns.Add("ProductDate");
            datatable.Columns.Add("Processor");
            datatable.Columns.Add("HDD");
            datatable.Columns.Add("RAM");
            datatable.Columns.Add("Price");
            datatable.Columns.Add("ImageName");

            DataRow newrow;
            foreach (var lt in sublist)
            {
                newrow = datatable.NewRow();
                newrow["LaptopID"] = lt.colLaptopID;
                newrow["LaptopName"] = lt.colLaptopName;
                newrow["LaptopType"] = lt.colLaptopType;
                newrow["ProductDate"] = lt.colProductDate;
                newrow["Processor"] = lt.colProcessor;
                newrow["HDD"] = lt.colHDD;
                newrow["RAM"] = lt.colRAM;
                newrow["Price"] = lt.colPrice.ToString() + " USD";
                newrow["ImageName"] = lt.colImageName;
                datatable.Rows.Add(newrow);
                datatable.AcceptChanges();
            }

            binding.AllowNew = true;
            binding.DataSource = datatable;
            dgwLaptopList.AutoGenerateColumns = false;
            dgwLaptopList.DataSource = binding;
        }
    }
}
