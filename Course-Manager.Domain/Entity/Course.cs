using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Manager.Domain.Entity
{
    public class Course
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        public string Name { get; private set; }
        
        public string ImageUrl { get; private set; } = "";


        [Required(ErrorMessage = "Adicione um valor para o curso")]
        public double Price { get; private set; }


        [Required(ErrorMessage = "Necessário um código")]
        public string Code { get; private set; }


        [Required(ErrorMessage = "É melhor que deixe o usuário saber a carga horária do curso")]
        public int Duration { get; private set; }


        [Required(ErrorMessage = "Informe a data de criação do curso")]
        public string ReleaseDate { get; private set; }


        [Required(ErrorMessage = "Deixe uma descrição sobre o curso")]
        public string  Description { get; private set; }

        public double Rating { get; private set; } = 0;

        public bool IsDeleted { get; private set; } = false;


        public Course( string name, string imageUrl, double price, string code, int duration, string releaseDate, string description, double rating, bool isDeleted)
        {
            Name = name;
            ImageUrl = imageUrl;
            Price = price;
            Code = code;
            Duration = duration;
            ReleaseDate = releaseDate;
            Description = description;
            Rating = rating;
            IsDeleted = isDeleted;
        }

        public void IsExcluded(bool option)
        {
            IsDeleted = option; 
        }

        public void UpdateCourse(Course course)
        {
            Name = course.Name;
            ImageUrl = course.ImageUrl;
            Price = course.Price;
            Code = course.Code;
            Duration = course.Duration;
            ReleaseDate = course.ReleaseDate;
            Description = course.Description;
            Rating = course.Rating;

        }
    }
}
