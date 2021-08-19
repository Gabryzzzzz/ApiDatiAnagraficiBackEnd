using ApiDatiAnagrafici.Entities.Database;
using ApiDatiAnagrafici.Messages;
using ApiDatiAnagrafici.Models;
using DatiAnagrafici.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatiAnagrafici.Services.Interface
{
    public interface IDatiAnagraficiService
    {
        Task<AddDatiResponse> AddDatiAsync(AddDatiRequest request);
        Task<GetAllDatiResponse> GetAllDatiAsync(GetAllDatiRequest request);
        Task<GetDatiByIdResponse> GetDatiByIdAsync(GetDatiByIdRequest request);
        Task<EditDatiResponse> EditDatiAsync(EditDatiRequest request);
        Task<RemoveDatiResponse> RemoveDatiAsync(RemoveDatiRequest request);
    }
}

namespace ApiDatiAnagrafici.Services
{
    public class DatiAnagraficiService : IDatiAnagraficiService
    {


        private readonly dati_anagraficiContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;
        public DatiAnagraficiService(dati_anagraficiContext db, ILogger<DatiAnagraficiService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        async Task<AddDatiResponse> IDatiAnagraficiService.AddDatiAsync(AddDatiRequest request)
        {
            var response = new AddDatiResponse();
            try
            {
                var dati = new Entities.Database.DatiAnagrafici()
                {
                    Nome = request.Nome,
                    Cognome = request.Cognome,
                    CodiceFiscale = request.CodiceFiscale,
                    DataDiNascita = request.DataDiNascita
                };

                _db.Add(dati);
                await _db.SaveChangesAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.SetException(ex);
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }

        async Task<EditDatiResponse> IDatiAnagraficiService.EditDatiAsync(EditDatiRequest request)
        {
            var response = new EditDatiResponse();
            try
            {
                var record = await _db.DatiAnagrafici.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (record == null) { throw new Exception(); }

                record.Nome = request.Nome;
                record.Cognome = request.Cognome;
                record.CodiceFiscale = request.CodiceFiscale;
                record.DataDiNascita = request.DataDiNascita;

                _db.Update(record);
                await _db.SaveChangesAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.SetException(ex);
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }

        async Task<GetAllDatiResponse> IDatiAnagraficiService.GetAllDatiAsync(GetAllDatiRequest request)
        {
            var response = new GetAllDatiResponse();
            try
            {
                response.Dati = await _db.DatiAnagrafici.Select(x => new GetDatiAnagraficiModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Cognome = x.Cognome,
                    CodiceFiscale = x.CodiceFiscale,
                    DataDiNascita = x.DataDiNascita
                }).ToListAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.SetException(ex);
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }

        async Task<GetDatiByIdResponse> IDatiAnagraficiService.GetDatiByIdAsync(GetDatiByIdRequest request)
        {
            var response = new GetDatiByIdResponse();
            try
            {
                var dati = await _db.DatiAnagrafici.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (dati == null) { throw new Exception(); }
                var datidto = new GetDatiAnagraficiModel()
                {
                    Id = dati.Id,
                    Nome = dati.Nome,
                    Cognome = dati.Cognome,
                    CodiceFiscale = dati.CodiceFiscale,
                    DataDiNascita = dati.DataDiNascita
                };

                response.Dati = datidto;
                await _db.SaveChangesAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.SetException(ex);
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }

        async Task<RemoveDatiResponse> IDatiAnagraficiService.RemoveDatiAsync(RemoveDatiRequest request)
        {
            var response = new RemoveDatiResponse();
            try
            {
                var dati = await _db.DatiAnagrafici.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (dati == null) { throw new Exception(); }
                
                _db.Remove(dati);
                await _db.SaveChangesAsync();

                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.SetException(ex);
                _logger.LogError(ex, ex.Message);
            }
            return response;
        }
    }
}
