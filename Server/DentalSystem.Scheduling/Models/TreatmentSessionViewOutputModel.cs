namespace DentalSystem.Scheduling.Models
{
    using System;
    using AutoMapper;
    using DentalSystem.Models;
    using DentalSystem.Scheduling.Data.Models;

    public record TreatmentSessionViewOutputModel : IMapFrom<TreatmentSession>
    {
        public string PatientName { get; set; }

        public string DentalTeamName { get; set; }

        public string TreatmentName { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public string Status { get; set; }

        public void Mapping(Profile mapper) => mapper
            .CreateMap<TreatmentSession, TreatmentSessionViewOutputModel>()
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.ReferenceId.ToString()))
            .ForMember(dest => dest.DentalTeamName, opt => opt.MapFrom(src => src.DentalTeam.Name))
            .ForMember(dest => dest.TreatmentName, opt => opt.MapFrom(src => src.Treatment.Name))
            .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Period.Start))
            .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.Period.End));
    }
}