using OutsourcingSystem.DTOs;
using OutsourcingSystem.Models;
using OutsourcingSystem.Repositories;

namespace OutsourcingSystem.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;


        public ClientService(IClientRepository clientRepository)
        {


            _clientRepository = clientRepository;


        }

        public void RegisterClient(ClientDTO clientDto)
        {
            // Validate the input DTO to ensure it is not null

            if (clientDto == null)
                throw new ArgumentNullException(nameof(clientDto), "Client data cannot be null.");

            // Check that the CompanyName is provided and not  null

            if (string.IsNullOrEmpty(clientDto.CompanyName))

                throw new ArgumentException("Company name is required.");

            try
            {
                // Map the data from ClientDTO to a new Client 
                var client = new Client
                {
                    CompanyName = clientDto.CompanyName, // Assign company name 
                    Industry = clientDto.Industry,       // Assign industry 
                    CreatedAt = DateTime.Now             //  date is current time
                };

                // Add the new client entity to the repository
                _clientRepository.Add(client);


            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while registering the client.", ex);
            }
        }


        public void UpdateClient(int id, ClientDTO updatedClientDto)
        {
            try
            {
                // Ensure the provided updated client data is not null

                if (updatedClientDto == null)

                    throw new ArgumentNullException(nameof(updatedClientDto), "Updated client data cannot be null.");

                // get the existing client from the repository using  ID
                var client = _clientRepository.GetById(id);

                if (client == null)

                    throw new KeyNotFoundException($"Client with ID {id} not found.");

                // Update client fields only if new values are provided, otherwise retain existing values
                client.CompanyName = updatedClientDto.CompanyName ?? client.CompanyName;
                client.Industry = updatedClientDto.Industry ?? client.Industry;

                // Update the client in the repository
                _clientRepository.Update(client);


            }
            catch (ArgumentNullException ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (KeyNotFoundException ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }

        public void SoftDeleteClient(int id)
        {
            // Validate the client ID to ensure >1 
            if (id <= 0)
                throw new ArgumentException("Client ID must be greater than zero.");

            try
            {
                // get the client by ID from the repository
                var client = _clientRepository.GetById(id);

                // Check if the client exists
                if (client == null)
                    throw new KeyNotFoundException($"Client with ID {id} not found.");

                // Mark the client as soft-deleted in the repository
                _clientRepository.SoftDelete(client);


            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while soft-deleting the client with ID {id}.", ex);
            }
        }

        public IEnumerable<ClientDTO> GetAllClients(string name, string industry, decimal? rating, int pageNumber, int pageSize)
        {
            // Validate pagination parameters to ensure they are positive integers

            if (pageNumber <= 0 || pageSize <= 0)
                throw new ArgumentException("Page number and page size must be greater than zero.");

            try
            {
                // get all clients from the repository and convert to a query object

                var query = _clientRepository.GetAll().AsQueryable();

                // Filter by name if a name is provided
                if (!string.IsNullOrEmpty(name))
                    query = query.Where(c => c.CompanyName.Contains(name, StringComparison.OrdinalIgnoreCase));

                // Filter by industry if an industry is provided
                if (!string.IsNullOrEmpty(industry))
                    query = query.Where(c => c.Industry.Contains(industry, StringComparison.OrdinalIgnoreCase));

                // Filter by rating if a rating is provided
                if (rating.HasValue)
                    query = query.Where(c => c.CommitmentRating >= rating);

                // Apply pagination
                return query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => new ClientDTO        // Map the Client entity to ClientDTO
                    {
                        ClientID = c.ClientID,
                        CompanyName = c.CompanyName,
                        Industry = c.Industry,
                        Rating = c.CommitmentRating,
                        CreatedAt = c.CreatedAt
                    })
                    .ToList(); // Execute the query and return the results as a list
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while retrieving clients.", ex);
            }
        }


        public IEnumerable<ClientDTO> GetClientsByIndustry(string industry)
        {
            // Validate the industry parameter to ensure it not null 

            if (string.IsNullOrEmpty(industry))
                throw new ArgumentException("Industry cannot be null or empty.");

            try
            {
                // get clients by industry from the repository

                // Map the result to a collection of ClientDTO 
                return _clientRepository.GetByIndustry(industry).Select(c => new ClientDTO
                {
                    ClientID = c.ClientID,        // Assign the client ID

                    CompanyName = c.CompanyName, // Assign the company name

                    Industry = c.Industry,       // Assign the industry

                    Rating = c.CommitmentRating,           // Assign the rating

                    CreatedAt = c.CreatedAt      // Assign the creation date
                });
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while retrieving clients in the industry '{industry}'.", ex);
            }
        }

        public ClientDTO GetClientById(int id)
        {
            try
            {
                // Validate that the ID is a positive number
                if (id <= 0)
                    throw new ArgumentException("The client ID must be greater than 0.", nameof(id));

                // Retrieve the client from the repository
                var client = _clientRepository.GetById(id);
                if (client == null)
                    throw new KeyNotFoundException($"Client with ID {id} not found.");

                // Map the client entity to a ClientDTO and return it
                return new ClientDTO
                {
                    ClientID = client.ClientID,
                    CompanyName = client.CompanyName,
                    Industry = client.Industry,
                    Rating = client.CommitmentRating,
                    CreatedAt = client.CreatedAt
                };
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine($"Validation Error: {ex.Message}");
                throw;
            }
            catch (KeyNotFoundException ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }
        }



        public IEnumerable<ClientDTO> GetClientsByRating(decimal rating)
        {
            // Validate input Rating must not be negative.

            if (rating < 0)
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be >= 0.");

            try
            {
                // get clients from the repository with a rating >= the specified value.

                return _clientRepository.GetByRating(rating).Select(c => new ClientDTO
                {
                    ClientID = c.ClientID,              // Map ClientID
                    CompanyName = c.CompanyName,        // Map Company Name
                    Industry = c.Industry,              // Map Industry
                    Rating = c.CommitmentRating,        // Map Rating
                    CreatedAt = c.CreatedAt             // Map CreatedAt timestamp
                });
            }
            catch (Exception ex)
            {

                throw new Exception($"An error occurred while retrieving clients with a rating >= {rating}.", ex);
            }
        }











    }
}
