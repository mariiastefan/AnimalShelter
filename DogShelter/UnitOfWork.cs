﻿using DogShelter.Repositories;
using DogShelter.Services;
using System;

namespace DogShelter
{
    public class UnitOfWork
    {
        public UserRepository Users { get; }
        public RoleRepository Roles { get; }
        public DogRepository Dogs { get; }
        public DetailsRepository Details { get; }
        public AdoptionRepository Adoptions { get; }   
        
        public DonationRepository Donations { get; }

        private readonly AppDBContext _dbContext;

        public UnitOfWork
        (
            AppDBContext dbContext,
            RoleRepository rolesRepository,
            UserRepository userRepository,
            DogRepository dogRepository,
            DetailsRepository detailsRepository,
            AdoptionRepository adoptionRepository,
            DonationRepository donationRepository
        )
        {
            _dbContext = dbContext;
            Roles = rolesRepository;
            Users = userRepository;
            Dogs = dogRepository;
            Details = detailsRepository;
            Adoptions = adoptionRepository;
            Donations = donationRepository;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
