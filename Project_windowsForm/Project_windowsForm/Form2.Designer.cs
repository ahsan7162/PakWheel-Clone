
namespace Project_windowsForm
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iPT_CourseProjectDataSet = new Project_windowsForm.IPT_CourseProjectDataSet();
            this.adsDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adsDataTableAdapter = new Project_windowsForm.IPT_CourseProjectDataSetTableAdapters.AdsDataTableAdapter();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brandnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemconditionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelyearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fueltypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transmissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enginecapacityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enginemileageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPT_CourseProjectDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adsDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.brandnameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.itemconditionDataGridViewTextBoxColumn,
            this.modelyearDataGridViewTextBoxColumn,
            this.fueltypeDataGridViewTextBoxColumn,
            this.transmissionDataGridViewTextBoxColumn,
            this.enginecapacityDataGridViewTextBoxColumn,
            this.enginemileageDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.adsDataBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(28, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(745, 393);
            this.dataGridView1.TabIndex = 0;
            // 
            // iPT_CourseProjectDataSet
            // 
            this.iPT_CourseProjectDataSet.DataSetName = "IPT_CourseProjectDataSet";
            this.iPT_CourseProjectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // adsDataBindingSource
            // 
            this.adsDataBindingSource.DataMember = "AdsData";
            this.adsDataBindingSource.DataSource = this.iPT_CourseProjectDataSet;
            // 
            // adsDataTableAdapter
            // 
            this.adsDataTableAdapter.ClearBeforeFill = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // brandnameDataGridViewTextBoxColumn
            // 
            this.brandnameDataGridViewTextBoxColumn.DataPropertyName = "brand_name";
            this.brandnameDataGridViewTextBoxColumn.HeaderText = "Brand Name";
            this.brandnameDataGridViewTextBoxColumn.Name = "brandnameDataGridViewTextBoxColumn";
            this.brandnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemconditionDataGridViewTextBoxColumn
            // 
            this.itemconditionDataGridViewTextBoxColumn.DataPropertyName = "item_condition";
            this.itemconditionDataGridViewTextBoxColumn.HeaderText = "Condition";
            this.itemconditionDataGridViewTextBoxColumn.Name = "itemconditionDataGridViewTextBoxColumn";
            this.itemconditionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modelyearDataGridViewTextBoxColumn
            // 
            this.modelyearDataGridViewTextBoxColumn.DataPropertyName = "model_year";
            this.modelyearDataGridViewTextBoxColumn.HeaderText = "Model Year";
            this.modelyearDataGridViewTextBoxColumn.Name = "modelyearDataGridViewTextBoxColumn";
            this.modelyearDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fueltypeDataGridViewTextBoxColumn
            // 
            this.fueltypeDataGridViewTextBoxColumn.DataPropertyName = "fuel_type";
            this.fueltypeDataGridViewTextBoxColumn.HeaderText = "Fuel";
            this.fueltypeDataGridViewTextBoxColumn.Name = "fueltypeDataGridViewTextBoxColumn";
            this.fueltypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // transmissionDataGridViewTextBoxColumn
            // 
            this.transmissionDataGridViewTextBoxColumn.DataPropertyName = "transmission";
            this.transmissionDataGridViewTextBoxColumn.HeaderText = "Transmission";
            this.transmissionDataGridViewTextBoxColumn.Name = "transmissionDataGridViewTextBoxColumn";
            this.transmissionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // enginecapacityDataGridViewTextBoxColumn
            // 
            this.enginecapacityDataGridViewTextBoxColumn.DataPropertyName = "engine_capacity";
            this.enginecapacityDataGridViewTextBoxColumn.HeaderText = "Engine Capacity";
            this.enginecapacityDataGridViewTextBoxColumn.Name = "enginecapacityDataGridViewTextBoxColumn";
            this.enginecapacityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // enginemileageDataGridViewTextBoxColumn
            // 
            this.enginemileageDataGridViewTextBoxColumn.DataPropertyName = "engine_mileage";
            this.enginemileageDataGridViewTextBoxColumn.HeaderText = "Engine Mileage";
            this.enginemileageDataGridViewTextBoxColumn.Name = "enginemileageDataGridViewTextBoxColumn";
            this.enginemileageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iPT_CourseProjectDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adsDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private IPT_CourseProjectDataSet iPT_CourseProjectDataSet;
        private System.Windows.Forms.BindingSource adsDataBindingSource;
        private IPT_CourseProjectDataSetTableAdapters.AdsDataTableAdapter adsDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brandnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemconditionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelyearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fueltypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transmissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enginecapacityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enginemileageDataGridViewTextBoxColumn;
    }
}