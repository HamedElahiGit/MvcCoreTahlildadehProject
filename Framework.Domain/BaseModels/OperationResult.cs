using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.BaseModels
{
  public  class OperationResult
    {
        
        public int RecordID { get; private set; }
        public string Operation { get; private  set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public DateTime OperationDate { get; private set; }

        public OperationResult(int recordId, string operation)
        {
            RecordID = recordId;
            Operation = operation;
            Success = false;
           OperationDate = DateTime.Now;
        }
        public OperationResult( string operation)
        {
          
            Operation = operation;
            Success = false;
            OperationDate = DateTime.Now;
        }

        public OperationResult Succeed(string Message)

        {
            this.Message = Message;
            this.Success = true;
            return this;
        }
        public OperationResult Succeed(string Message,int RecordID)

        {
            this.Message = Message;
            this.Success = true;
            this.RecordID = RecordID;
            return this;
        }
        public OperationResult Failed(string Message)

        {
            this.Message = Message;
            this.Success = false;
            return this;
        }
    }
}
