namespace Evolution_3._0
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGeneration = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.btn_create = new System.Windows.Forms.Button();
            this.timerTurn = new System.Windows.Forms.Timer(this.components);
            this.labelCellsShow = new System.Windows.Forms.Label();
            this.labelCells = new System.Windows.Forms.Label();
            this.dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.labelFoods = new System.Windows.Forms.Label();
            this.labelFoodShow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneration
            // 
            this.btnGeneration.Location = new System.Drawing.Point(1253, 23);
            this.btnGeneration.Name = "btnGeneration";
            this.btnGeneration.Size = new System.Drawing.Size(75, 23);
            this.btnGeneration.TabIndex = 0;
            this.btnGeneration.Text = "generation";
            this.btnGeneration.UseVisualStyleBackColor = true;
            this.btnGeneration.Click += new System.EventHandler(this.btnGeneration_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(1253, 72);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerDraw
            // 
            this.timerDraw.Interval = 15;
            this.timerDraw.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(1253, 113);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // timerTurn
            // 
            this.timerTurn.Interval = 50;
            this.timerTurn.Tick += new System.EventHandler(this.timerTurn_Tick);
            // 
            // labelCellsShow
            // 
            this.labelCellsShow.AutoSize = true;
            this.labelCellsShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCellsShow.Location = new System.Drawing.Point(1170, 23);
            this.labelCellsShow.Name = "labelCellsShow";
            this.labelCellsShow.Size = new System.Drawing.Size(61, 26);
            this.labelCellsShow.TabIndex = 3;
            this.labelCellsShow.Text = "Cells";
            // 
            // labelCells
            // 
            this.labelCells.AutoSize = true;
            this.labelCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCells.Location = new System.Drawing.Point(1170, 58);
            this.labelCells.Name = "labelCells";
            this.labelCells.Size = new System.Drawing.Size(24, 26);
            this.labelCells.TabIndex = 4;
            this.labelCells.Text = "0";
            // 
            // dataGridViewInfo
            // 
            this.dataGridViewInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewInfo.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfo.Location = new System.Drawing.Point(1080, 142);
            this.dataGridViewInfo.Name = "dataGridViewInfo";
            this.dataGridViewInfo.Size = new System.Drawing.Size(260, 312);
            this.dataGridViewInfo.TabIndex = 9;
            // 
            // labelFoods
            // 
            this.labelFoods.AutoSize = true;
            this.labelFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFoods.Location = new System.Drawing.Point(1092, 58);
            this.labelFoods.Name = "labelFoods";
            this.labelFoods.Size = new System.Drawing.Size(24, 26);
            this.labelFoods.TabIndex = 11;
            this.labelFoods.Text = "0";
            // 
            // labelFoodShow
            // 
            this.labelFoodShow.AutoSize = true;
            this.labelFoodShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFoodShow.Location = new System.Drawing.Point(1092, 23);
            this.labelFoodShow.Name = "labelFoodShow";
            this.labelFoodShow.Size = new System.Drawing.Size(72, 26);
            this.labelFoodShow.TabIndex = 10;
            this.labelFoodShow.Text = "Foods";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 661);
            this.Controls.Add(this.labelFoods);
            this.Controls.Add(this.labelFoodShow);
            this.Controls.Add(this.dataGridViewInfo);
            this.Controls.Add(this.labelCells);
            this.Controls.Add(this.labelCellsShow);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btnGeneration);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Evolution 3.0";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneration;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Timer timerTurn;
        private System.Windows.Forms.Label labelCellsShow;
        private System.Windows.Forms.Label labelCells;
        private System.Windows.Forms.DataGridView dataGridViewInfo;
        private System.Windows.Forms.Label labelFoods;
        private System.Windows.Forms.Label labelFoodShow;
    }
}

