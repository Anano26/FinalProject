using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentSubjectController : ControllerBase
    {
        private readonly IGenericRepository<StudentSubject> _repository;
        //private readonly IGenericRepository<Student> _studentrepository;
        //private readonly IGenericRepository<Subject> _subjectRepository;


        public StudentSubjectController(IGenericRepository<StudentSubject> repository)
            //, 
            //                            IGenericRepository<Student> studentRepository, 
            //                            IGenericRepository<Subject> subjectRepository)
        {
            _repository = repository;
            //_studentrepository = studentRepository;
            //_subjectRepository = subjectRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentSubjectModel>> GetAllAsync()
        {
            var StudentSubjects = await _repository.GetAllAsync();

            var rViewModel = StudentSubjects.Select(x => new StudentSubjectModel
            {
                Point = x.Point.ToString()
            });

            return rViewModel;
        }

        [HttpGet("{id}")]
        public async Task<StudentSubjectModel> GetOne(int id)
        {
            var studentSubject = await _repository.GetByIdAsync(id);

            return new StudentSubjectModel
            {
                Point = studentSubject.Point.ToString()
            };
        }

        [HttpPost]
        public async Task Add(StudentSubjectModel studentSubject)
        {
            await _repository.AddAsync(new StudentSubject
            {
                Point = Int32.Parse(studentSubject.Point)
            });
            await _repository.SaveAsync();
        }

        [HttpDelete("~/Delete")]
        public void DeleteOneAsync(int id)
        {
            _repository.Delete(id);
            _repository.SaveAsync();
        }

        [HttpGet("~/AddStudentToSubject")]
        public async void AddStudentToSubject(int studentId, int subjectId)
        {
            var studentSubjects = await _repository.GetAllAsync();
            //var students = await _studentrepository.GetAllAsync();
            //var subjects = await _subjectRepository.GetAllAsync();

            //var studentSubject = new StudentSubject
            //{
            //    Student = student,
            //    Subject = subject
            //};

            //await _repository.AddAsync(studentSubject);
            //await _repository.SaveAsync();
        }
    }
}
