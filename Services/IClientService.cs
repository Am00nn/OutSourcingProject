﻿using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;

namespace OutsourcingSystem.Services
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetAllClients(string name, string industry, decimal? rating, int pageNumber, int pageSize);
        ClientDTO GetClientById(int id);
        IEnumerable<ClientByIndestry> GetClientsByIndustry(string industry);
        IEnumerable<ClientByIndestry> GetClientsByRating(decimal rating);
         void RegisterClient(UserInputDto client);
        void SoftDeleteClient(int id);
        void UpdateClient(int id, UpdateClientData updatedClientDto);

       


    }
}