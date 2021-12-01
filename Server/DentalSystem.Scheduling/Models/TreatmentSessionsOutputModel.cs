namespace DentalSystem.Scheduling.Models
{
    using System;
    using AutoMapper;
    using DentalSystem.Models;
    using DentalSystem.Scheduling.Data.Models;

    public record TreatmentSessionsOutputModel : IMapFrom<TreatmentSession>
    {
        public Guid PatientReferenceId { get; set; }

        public Guid DentalTeamReferenceId { get; set; }

        public Guid TreatmentReferenceId { get; set; }

        public DateTimeOffset Start { get; set; }

        public DateTimeOffset End { get; set; }

        public string Status { get; set; }

        public void Mapping(Profile mapper) => mapper
            .CreateMap<TreatmentSession, TreatmentSessionsOutputModel>()
            .ForMember(dest => dest.PatientReferenceId, opt => opt.MapFrom(src => src.Patient.ReferenceId))
            .ForMember(dest => dest.DentalTeamReferenceId, opt => opt.MapFrom(src => src.DentalTeam.ReferenceId))
            .ForMember(dest => dest.TreatmentReferenceId, opt => opt.MapFrom(src => src.Treatment.ReferenceId))
            .ForMember(dest => dest.Start, opt => opt.MapFrom(src => src.Period.Start))
            .ForMember(dest => dest.End, opt => opt.MapFrom(src => src.Period.End));
    }
}