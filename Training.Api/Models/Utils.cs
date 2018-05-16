using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Training.Api.Dtos;

namespace Training.Api.Models
{
    public static class Utils
    {


        public class AutoMapperProfiles : Profile
        {
            public AutoMapperProfiles()
            {
                CreateMap<Car, CarDto>()
                .ForMember(dest => dest.FullLabel,
                        opt => opt.MapFrom(src => src.ModelName + " " + src.BrandName.ToString()))
                .ForMember(dest => dest.Age,
                        opt => opt.ResolveUsing(src => src.YearOfConstruction.CalculateAge())
                );
            }


        }


        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static int CalculateAge(this int year)
        {
            return DateTime.Now.Year - year;
        }

        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

    }



}
