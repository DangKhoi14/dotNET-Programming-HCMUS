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
                                ProductDate = DateTime.ParseExact(xlRange.Cells[i, j].Value2.ToString(),"dd/MM/yyyy", CultureInfo.InvariantCulture);
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
            loadData = 1;
            datatable = new DataTable();
            LtpList.Clear();

            int colCount = 9;
            int NumDataRow = ReadDataFromFile(LtpList, ExcelFilePath, colCount);

            // Binding data to the grid
            binding.AllowNew = true;
            binding.DataSource = LtpList;
            dgwLaptopList.AutoGenerateColumns = false;
            dgwLaptopList.DataSource = binding;

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

            try
            {
                if (CurrentLaptopIndex >= 0 && CurrentLaptopIndex < LtpList.Count)
                {
                    picImage.Image = Image.FromFile(ProjectPath + subPath + LtpList[CurrentLaptopIndex].ImageName);
                }
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row;
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                row = datatable.Rows[i];

                LtpList[i].LaptopName = row["LaptopName"].ToString();
                LtpList[i].LaptopType = row["LaptopType"].ToString();

                // Handle ProductDate parsing
                string dateString = row["ProductDate"].ToString();
                if (DateTime.TryParse(dateString, out DateTime parsedDate))
                {
                    LtpList[i].ProductDate = parsedDate;
                }
                else
                {
                    MessageBox.Show($"Invalid date format for row {i + 1}: {dateString}");
                    continue; // Skip this row if the date is invalid
                }

                LtpList[i].Processor = row["Processor"].ToString();
                LtpList[i].HDD = row["HDD"].ToString();
                LtpList[i].RAM = row["RAM"].ToString();

                string StringPrice = row["Price"].ToString();
                if (StringPrice.Contains(" "))
                {
                    LtpList[i].Price = Convert.ToInt32(StringPrice.Substring(0, StringPrice.IndexOf(" ")));
                }
                else
                {
                    LtpList[i].Price = Convert.ToInt32(StringPrice);
                }

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
            newrow["ImageName"] = lt.LaptopName + ".png";
            datatable.Rows.Add(newrow);
            datatable.AcceptChanges();

            MessageBox.Show("Finish Adding");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure there is a valid selection
            if (dgwLaptopList.CurrentRow == null || dgwLaptopList.CurrentRow.IsNewRow)
            {
                MessageBox.Show("No laptop selected for deletion.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected index
            int selectedIndex = dgwLaptopList.CurrentRow.Index;

            // Ensure the index is within the valid range
            if (selectedIndex < 0 || selectedIndex >= LtpList.Count)
            {
                MessageBox.Show("No laptop selected for deletion.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieve the laptop object
            Laptop selectedLaptop = LtpList[selectedIndex];

            // Confirm deletion
            string question = $"Do you want to delete Laptop: {selectedLaptop.LaptopName}?";
            DialogResult result = MessageBox.Show(question, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Remove the item from the list
                LtpList.RemoveAt(selectedIndex);

                // Remove the item from the binding source if it exists
                if (selectedIndex < binding.Count)
                {
                    binding.RemoveAt(selectedIndex);
                }

                // Refresh the DataGridView
                dgwLaptopList.ClearSelection();
                binding.ResetBindings(false);

                MessageBox.Show("Laptop deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            catch (SqlException ex)
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

            binding.AllowNew = true;
            binding.DataSource = LtpList;
            dgwLaptopList.AutoGenerateColumns = false;
            dgwLaptopList.DataSource = binding;
        }

        private void WriteDataToExcelFile(List<Laptop> LtpList, string ExcelPath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(ExcelFilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Worksheets[1];

            Excel.Range xlRange;
            string[,] Data = new string[1, 9];

            int idxRow = 2;
            foreach (Laptop l in LtpList)
            {
                Data[0, 0] = l.LaptopID.ToString();
                Data[0, 1] = l.LaptopName;
                Data[0, 2] = l.LaptopType;
                Data[0, 3] = l.ProductDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                Data[0, 4] = l.Processor;
                Data[0, 5] = l.HDD;
                Data[0, 6] = l.RAM;
                Data[0, 7] = l.Price.ToString();
                Data[0, 8] = l.ImageName;

                xlRange = xlWorksheet.get_Range("A" + idxRow.ToString(), "I" + idxRow.ToString());
                xlRange.Value2 = Data;

                idxRow++;
            }

            xlWorkbook.Save();
            xlWorkbook.Close();
            xlApp.Quit();
        }

        private void WriteDataToSQLServer(List<Laptop> LtpList, string connectionString)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                string truncateQuery = "TRUNCATE TABLE Laptop";
                using (var truncateCommand = new SqlCommand(truncateQuery, cnn))
                {
                    truncateCommand.ExecuteNonQuery();
                }

                string insertQuery = @"INSERT INTO Laptop (
                                LaptopID, LaptopName, LaptopType, ProductDate, 
                                Processor, HDD, RAM, Price, ImageName) 
                              VALUES (
                                @LaptopID, @LaptopName, @LaptopType, @ProductDate, 
                                @Processor, @HDD, @RAM, @Price, @ImageName)";

                foreach (var laptop in LtpList)
                {
                    using (var command = new SqlCommand(insertQuery, cnn))
                    {
                        command.Parameters.AddWithValue("@LaptopID", laptop.LaptopID);
                        command.Parameters.AddWithValue("@LaptopName", laptop.LaptopName);
                        command.Parameters.AddWithValue("@LaptopType", laptop.LaptopType);
                        command.Parameters.AddWithValue("@ProductDate", laptop.ProductDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                        command.Parameters.AddWithValue("@Processor", laptop.Processor);
                        command.Parameters.AddWithValue("@HDD", laptop.HDD);
                        command.Parameters.AddWithValue("@RAM", laptop.RAM);
                        command.Parameters.AddWithValue("@Price", laptop.Price);
                        command.Parameters.AddWithValue("@ImageName", laptop.ImageName);

                        command.ExecuteNonQuery();
                    }
                }
            }

            Console.WriteLine("Data written to SQL Server successfully!");
        }

        private void btnUpdateToDataSource_Click(object sender, EventArgs e)
        {
            WriteDataToExcelFile(LtpList, ExcelFilePath);

            WriteDataToSQLServer(LtpList, connectionString);

            MessageBox.Show("Finish update to DataSource: Excel - SQL Server");
        }
    }
}
