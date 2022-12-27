using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Repository.Repositories;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly IGenericRepository<Subject> _repository;
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<StudentSubject> _studentSubjectRepository;

        public SubjectController(IGenericRepository<Subject> subjectRepository, IGenericRepository<Student> studentRepository, IGenericRepository<StudentSubject> studentSubjectRepository)
        {
            _repository = subjectRepository;
            _studentRepository = studentRepository;
            _studentSubjectRepository = studentSubjectRepository;
        }

        /// <summary>
        /// Gets all subjects
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SubjectModel>> GetAllAsync()
        {
            var Subjects = await _repository.GetAllAsync();

            var rViewModel = Subjects.Select(x => new SubjectModel
            {
                Name = x.Name,
                Credit = x.Credit.ToString(),
                LowerBound = x.Credit.ToString()
            });

            return rViewModel;
        }

        /// <summary>
        /// Gets one subject
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<SubjectModel> GetOne(int id)
        {
            var subject = await _repository.GetByIdAsync(id);

            return new SubjectModel
            {
                Name = subject.Name,
                Credit = subject.Credit.ToString(),
                LowerBound = subject.Credit.ToString()
            };
        }

        /// <summary>
        /// Deletes one subject
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpDelete]
        public async void DeleteOne(int id)
        {
            _repository.Delete(id);
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Adds one subject
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(SubjectModel subject)
        {
            await _repository.AddAsync(new Subject
            {
                Name = subject.Name,
                Credit = Int32.Parse(subject.Credit),
                LowerBound = Int32.Parse(subject.LowerBound)

            });
            await _repository.SaveAsync();
        }

        /// <summary>
        /// Adds one student to a subject
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        [HttpPost("~/AddStudentToCourse")]
        public async Task AddStudentToCourse(int subjectId, int studentId)
        {
            var subject = await _repository.GetByIdAsync(subjectId);
            var student = await _studentRepository.GetByIdAsync(studentId);

            var studentsInSubject = await _studentSubjectRepository.GetAllAsync(x => x.Subject.Id == subjectId);

            if (studentsInSubject.Any(x=>x.Subject.Id == subjectId && x.Student.Id == studentId)) {
                throw new Exception("Student already in course.");
            }

            if (studentsInSubject.Count() > 30)
            {
                throw new Exception("Cannot add student to course. 30 students max has been reached.");
            }

            var studentSubject = new StudentSubject
            {
                Subject = subject,
                Student = student
            };

            await _studentSubjectRepository.AddAsync(studentSubject);
            await _studentSubjectRepository.SaveAsync();
        }
    }
}
