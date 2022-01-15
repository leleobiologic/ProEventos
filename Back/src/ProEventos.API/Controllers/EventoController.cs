﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]{
        new Evento() {
            EventoId = 1,
            Tema = "Angular 11 .net5",
            Local = "Belo Horizonte",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemURL = "foto.jpg"
        },
        new Evento() {
            EventoId = 2,
            Tema = "Angular 50",
            Local = "Ribeirão Preto",
            QtdPessoas = 350,
            DataEvento = DateTime.Now.AddDays(3).ToString(),
            ImagemURL = "foto.gif"
        }
    };




        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            var teste = 1;
            return _evento.Where(x => x.EventoId == id);
        }
        [HttpPost]
        public string Post()
        {
            return "Exemplo Post";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put Id: {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete Id: {id}";
        }
    }
}
