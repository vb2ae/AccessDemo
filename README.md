# Access Demo

I saw a question on Microsof docs Q&A site about an error when getting data from an access database with c#.  For this app I used a .net 5 windows forms app.   The same steps should work with a .net framework app.


First I created a .net 5.0 windows forms app.   Then I added the NuGet Package System.Data.OleDb.  

![NuGet Package Manager](/images/oledb.PNG) 

Then you can add some code to load the database into a data table


            string connectionString =
                $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={System.Environment.CurrentDirectory}\\northwind.mdb;Persist Security Info=False;";
            try
            {
                var conn = new OleDbConnection(connectionString);
                conn.Open();
                var cmd = new OleDbCommand("Select * from products", conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            
            
If you get an error about not being able to find the Micorosft.Ace.OldDB.12.0 drivers you need to install the drivers for you computers processor type

https://www.microsoft.com/en-us/download/confirmation.aspx?id=13255


