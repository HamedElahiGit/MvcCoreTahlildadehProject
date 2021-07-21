using Framework.Domain.BaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.Domain.Models;
using Tutorial.Domain.Services;
using Tutorial.Persistence.EF.Context;

namespace Tutorial.Persistence.EF.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly TutorialDbContext db;
        public FileRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }

        public OperationResult AddNew(File Current)
        {
            OperationResult op = new OperationResult("AddNew");
            try
            {

                this.db.Files.Add(Current);
                db.SaveChanges();
                return op.Succeed("File Added Successfully", Current.Id);
            }
            catch (Exception ex)
            {
                return op.Failed("File Add Failed : " + ex.Message);
            }
        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete File");
            try
            {
                var file = db.Files.FirstOrDefault(x => x.Id == ID);
                if (file == null)
                {
                    return op.Failed("This File does not Exist");
                }
                db.Files.Remove(file);
                db.SaveChanges();
                return op.Succeed("File Removed Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("File Remove Failed " + ex.Message);
            }

        }

        public File Get(int ID)
        {
            return db.Files.FirstOrDefault(x => x.Id == ID);
        }

        public List<File> GetAll()
        {
            return db.Files.ToList();
        }

        public OperationResult Update(File Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update File");
            try
            {

                this.db.Files.Attach(Current);
                db.Entry<File>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update File  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("File Update Failed : " + ex.Message);

            }
        }
    }
}
