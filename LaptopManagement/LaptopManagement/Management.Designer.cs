namespace LaptopManagement
{
    partial class Management
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Management));
            btnLoadFromExcel = new Button();
            btnLoadFromSQL = new Button();
            dgwLaptopList = new DataGridView();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnUpdateToDataSource = new Button();
            picImage = new PictureBox();
            lblExit = new Label();
            panel1 = new Panel();
            colLaptopID = new DataGridViewTextBoxColumn();
            colLaptopName = new DataGridViewTextBoxColumn();
            colLaptopType = new DataGridViewTextBoxColumn();
            colProductDate = new DataGridViewTextBoxColumn();
            colProcessor = new DataGridViewTextBoxColumn();
            colHDD = new DataGridViewTextBoxColumn();
            colRAM = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colImageName = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgwLaptopList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            SuspendLayout();
            // 
            // btnLoadFromExcel
            // 
            btnLoadFromExcel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLoadFromExcel.Location = new Point(12, 12);
            btnLoadFromExcel.Name = "btnLoadFromExcel";
            btnLoadFromExcel.Size = new Size(350, 30);
            btnLoadFromExcel.TabIndex = 0;
            btnLoadFromExcel.Text = "Load Data From Excel";
            btnLoadFromExcel.UseVisualStyleBackColor = true;
            // 
            // btnLoadFromSQL
            // 
            btnLoadFromSQL.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnLoadFromSQL.Location = new Point(378, 12);
            btnLoadFromSQL.Name = "btnLoadFromSQL";
            btnLoadFromSQL.Size = new Size(350, 30);
            btnLoadFromSQL.TabIndex = 0;
            btnLoadFromSQL.Text = "Load Data From SQL Server";
            btnLoadFromSQL.UseVisualStyleBackColor = true;
            // 
            // dgwLaptopList
            // 
            dgwLaptopList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwLaptopList.Columns.AddRange(new DataGridViewColumn[] { colLaptopID, colLaptopName, colLaptopType, colProductDate, colProcessor, colHDD, colRAM, colPrice, colImageName });
            dgwLaptopList.Location = new Point(12, 54);
            dgwLaptopList.MultiSelect = false;
            dgwLaptopList.Name = "dgwLaptopList";
            dgwLaptopList.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgwLaptopList.Size = new Size(943, 270);
            dgwLaptopList.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 336);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(537, 40);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(12, 382);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(537, 40);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 428);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(537, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdateToDataSource
            // 
            btnUpdateToDataSource.Location = new Point(12, 511);
            btnUpdateToDataSource.Name = "btnUpdateToDataSource";
            btnUpdateToDataSource.Size = new Size(537, 50);
            btnUpdateToDataSource.TabIndex = 3;
            btnUpdateToDataSource.Text = "Update To Data Source";
            btnUpdateToDataSource.UseVisualStyleBackColor = true;
            // 
            // picImage
            // 
            picImage.Location = new Point(555, 336);
            picImage.Name = "picImage";
            picImage.Size = new Size(400, 225);
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.TabIndex = 4;
            picImage.TabStop = false;
            // 
            // lblExit
            // 
            lblExit.AutoSize = true;
            lblExit.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lblExit.ForeColor = Color.Red;
            lblExit.Location = new Point(837, 18);
            lblExit.Name = "lblExit";
            lblExit.Size = new Size(44, 18);
            lblExit.TabIndex = 5;
            lblExit.Text = "EXIT";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(14, 490);
            panel1.Name = "panel1";
            panel1.Size = new Size(533, 1);
            panel1.TabIndex = 6;
            // 
            // colLaptopID
            // 
            colLaptopID.DataPropertyName = "ID";
            colLaptopID.HeaderText = "ID";
            colLaptopID.Name = "colLaptopID";
            colLaptopID.Width = 80;
            // 
            // colLaptopName
            // 
            colLaptopName.DataPropertyName = "Name";
            colLaptopName.HeaderText = "Name";
            colLaptopName.Name = "colLaptopName";
            colLaptopName.Width = 110;
            // 
            // colLaptopType
            // 
            colLaptopType.DataPropertyName = "Type";
            colLaptopType.HeaderText = "Type";
            colLaptopType.Name = "colLaptopType";
            // 
            // colProductDate
            // 
            colProductDate.DataPropertyName = "ProductDate";
            colProductDate.HeaderText = "Product Date";
            colProductDate.Name = "colProductDate";
            // 
            // colProcessor
            // 
            colProcessor.DataPropertyName = "Processor";
            colProcessor.HeaderText = "Processor";
            colProcessor.Name = "colProcessor";
            colProcessor.Width = 110;
            // 
            // colHDD
            // 
            colHDD.DataPropertyName = "HDD";
            colHDD.HeaderText = "HDD";
            colHDD.Name = "colHDD";
            // 
            // colRAM
            // 
            colRAM.DataPropertyName = "RAM";
            colRAM.HeaderText = "RAM";
            colRAM.Name = "colRAM";
            // 
            // colPrice
            // 
            colPrice.DataPropertyName = "Price";
            colPrice.HeaderText = "Price";
            colPrice.Name = "colPrice";
            // 
            // colImageName
            // 
            colImageName.DataPropertyName = "ImageName";
            colImageName.HeaderText = "Image Name";
            colImageName.Name = "colImageName";
            // 
            // Management
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 573);
            Controls.Add(panel1);
            Controls.Add(lblExit);
            Controls.Add(picImage);
            Controls.Add(btnUpdateToDataSource);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(dgwLaptopList);
            Controls.Add(btnLoadFromSQL);
            Controls.Add(btnLoadFromExcel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Management";
            Text = "Laptop Management";
            ((System.ComponentModel.ISupportInitialize)dgwLaptopList).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadFromExcel;
        private Button btnLoadFromSQL;
        private DataGridView dgwLaptopList;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnUpdateToDataSource;
        private PictureBox picImage;
        private Label lblExit;
        private Panel panel1;
        private DataGridViewTextBoxColumn colLaptopID;
        private DataGridViewTextBoxColumn colLaptopName;
        private DataGridViewTextBoxColumn colLaptopType;
        private DataGridViewTextBoxColumn colProductDate;
        private DataGridViewTextBoxColumn colProcessor;
        private DataGridViewTextBoxColumn colHDD;
        private DataGridViewTextBoxColumn colRAM;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colImageName;
    }
}
