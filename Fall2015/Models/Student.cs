using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fall2015.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Wrong, stupid user. You must have a firstname.")]
        public String Firstname { get; set; }

        [Required]
        public String Lastname { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        public String MobilePhone { get; set; }

        public String ImageFilePath { get; set; }

        //part of the many-to-many relationsship between Student and Competency
        public ICollection<Competency> Competencies { get; set; }

        public void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            if (image == null) return;
            RemoveOldImage(serverPath);
            //ImageModel
            Guid guid = Guid.NewGuid();
            ImageModel.ResizeAndSave(serverPath + pathToFile, guid.ToString(), image.InputStream, 200);

            ImageFilePath = pathToFile + guid.ToString() + ".jpg";
        }

        public void RemoveOldImage(String serverPath)
        {
            if (ImageFilePath != null)
            {
                System.IO.File.Delete(serverPath + ImageFilePath);
            }
            this.ImageFilePath = null;
        }

    }
}