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
    public class ImageRepository : IImageRepository
    {
        private readonly TutorialDbContext db;
        public ImageRepository(TutorialDbContext dbContext)
        {
            db = dbContext;
        }
        public OperationResult AddNew(Image Current)
        {
            OperationResult op = new OperationResult("Add New Image");
            try
            {
                this.db.Images.Add(Current);
                db.SaveChanges();
                return op.Succeed("Image Added Successfully", Current.Id);
            }
            catch (Exception ex)
            {
                return op.Failed("Image Add Failed : " + ex.Message);
            }
        }

        public OperationResult Delete(int ID)
        {
            OperationResult op = new OperationResult(ID, "Delete Image");
            try
            {
                var course = db.Images.FirstOrDefault(x => x.Id == ID);
                if (course == null)
                {
                    return op.Failed("This Image does not Exist");
                }

                db.Images.Remove(course);
                db.SaveChanges();
                return op.Succeed("Image Removed Successfully");

            }
            catch (Exception ex)
            {
                return op.Failed("Image Remove Failed " + ex.Message);
            }
        }

        public Image Get(int ID)
        {
            return this.db.Images.FirstOrDefault(x => x.Id == ID);
        }

        public List<Image> GetAll()
        {
            return this.db.Images.ToList();
        }

        public OperationResult Update(Image Current)
        {
            OperationResult op = new OperationResult(Current.Id, "Update Image");
            try
            {

                this.db.Images.Attach(Current);
                db.Entry<Image>(Current).State = EntityState.Modified;
                db.SaveChanges();
                return op.Succeed("Update Image  Successfully");
            }
            catch (Exception ex)
            {
                return op.Failed("Image Update Failed : " + ex.Message);

            }
        }
    }
}
