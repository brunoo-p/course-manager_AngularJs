using Course_Manager.Domain.Entity;
using Course_Manager.Domain.Interface;
using Course_Manager.Service.Filter;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace Course_Manager.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ICourseRepository _repository;
        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Este endpoint busca todos os cursos cadastrados no sistema
        /// </summary>
        /// <returns>Retorna status 200 com um enumerado de cursos</returns>
        [SwaggerResponse(statusCode: 200, description: "Lista de cursos cadastrados", type: typeof(Course))]
        [HttpGet]
        public ActionResult<IEnumerable<Course>> AllCourses()
        {
            var courses = _repository.GetAll();

            return StatusCode(200, courses);
        }

        /// <summary>
        /// Faz uma busca pelo ID de um curso específico.
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Caso o curso seja encontrado retorna um status:200 com o curso. Se não encontrado retorna status:404</returns>
        [SwaggerResponse(statusCode: 200, description: "Curso encontrado", type: typeof(Course))]
        [SwaggerResponse(statusCode: 404, description: "Este curso nao existe cadastrado no sistema")]
        [HttpGet(":id")]
        public ActionResult<Course> CourseById( int id )
        {
            var course = _repository.GetById(id);

            if(course == null)
            {
                return StatusCode(404, "O curso procurado não está cadastrado");
            }

            return StatusCode(200, course);
        }


        /// <summary>
        /// Para Adicionar um novo curso use este endpoint
        /// </summary>
        /// <param name="course"></param>
        /// <returns>Retorna status:301 se tudo OK ou status:500 caso algum erro interno</returns>
        [SwaggerResponse(statusCode: 301, description: "Curso Adicionado com sucesso")]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios não foram preenchidos", type: typeof(CourseValidation))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", type: typeof(GenericError))]
        [HttpPost]
        public ActionResult AddCourse( Course course )
        {
            try {

                _repository.Add(course);
                return StatusCode(301, "Curso Adicionado com sucesso");

            } catch ( Exception ex )
            {
                return StatusCode(500, $"Erro ao adicionar curso. :{ex} ");
            }

        }
        
    }
}