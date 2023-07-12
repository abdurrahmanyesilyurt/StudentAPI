using Students.Data;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Repo
{
    public class StudentRepo : IStudent
    {

        private readonly StudentDbContext _db;

        public StudentRepo(StudentDbContext db)
        {
            _db = db;
        }

        public IQueryable<Student> GetStudents => _db.Students;

        public void Delete(int? Id)
        {
            Student student = _db.Students.Find(Id);
            _db.Students.Remove(student);
            _db.SaveChanges();
        }

        public Student GetStudent(int? Id)
        {
           Student student= _db.Students.Find(Id);
           return student;
        }

        public void Save(Student student)
        {
            if(student.Id==0)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
            }
            else if(student.Id!=0) {
                Student _Enity=_db.Students.Find(student.Id);
                _Enity.FirstName=student.FirstName;
                _Enity.LastName=student.LastName;
                _Enity.gender = student.gender;
                _db.SaveChanges();

            }
        }
    }
}
