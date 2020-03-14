using OrderTrackingSystemProj.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlDependencyProjectSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void SQLDependancyMonitoring()
        {


            string connectionString = ""; // your Connection string 
            int table_1_Identey = 1;
            int table_2_Identiy = 2;
            // you must add  unique identity for each table motioning 
            SqlDependencyEx listener1 = new SqlDependencyEx(connectionString, "Database name", "your Table Name", identity: table_1_Identey);
            SqlDependencyEx listener2 = new SqlDependencyEx(connectionString, "your Database name", "your table name", identity: table_1_Identey);
            listener1.TableChanged += (o, ee) =>
            {
                // Here changes in table 1
                // you got  the rows has been added/ updated/ deleted
                // you got row as as XML format string
                string UpdatedRow = ee.Data.ToString();

            };
            // e.Data contains actual changed data in the XML format
            listener2.TableChanged += (o, ee) =>
            {
                // Here changes in table 2
                // you got  the rows has been added/ updated/ deleted
                // you got row as as XML format string
                string UpdatedRow = ee.Data.ToString();
            };

            listener1.Start(); //  starting Listing for table 1
            listener2.Start(); //  starting Listing for table 2

            // YOU ,MUST STOP LISTING ON END OF YOUR APPLICATION 
            listener1.Stop();// STOP LISTENIG  FOR TABLE 1
            listener2.Stop();// STOP LISTENIG  FOR TABLE 2

        }
    }
}
