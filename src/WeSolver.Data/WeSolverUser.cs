using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;

namespace WeSolver.Data
{

    public class WeSolverUser : TableServiceEntity
    {
        public WeSolverUser()
        {
            //Create a separate partition for each day to 
            //ensure load balancing of the data across storage nodes.
            PartitionKey = DateTime.UtcNow.ToString("MMddyyyy");
            RowKey = Guid.NewGuid().ToString();
        }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public string FacebookUid { get; set; }
    }
}
