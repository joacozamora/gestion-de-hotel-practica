﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservas.BData;
using Reservas.BData.Data.Entity;

namespace HotelApp.Server.Controllers
{
    [ApiController]
    [Route("api/Habitacion")]
    public class HabitacionesController : ControllerBase
    {
        private readonly Context context;

        public HabitacionesController(Context context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Habitacion>>> Get()
        {
            var habitaciones = await context.Habitaciones.ToListAsync();
            return habitaciones;
        }

        [HttpGet("int:Id")]
        public async Task<ActionResult<Habitacion>> GetNroHabitacion(int nrohab)
        {
            var buscar = await context.Habitaciones.FirstOrDefaultAsync(c => c.Nhab==nrohab);

            if (buscar is null)
            {
                return BadRequest($"No se encontro la habitacion de numero: {nrohab}");
            }

            return buscar;
        }

        [HttpPost] 
        public async Task<ActionResult<int>> Post(Habitacion habitacion)
        {

            Habitacion nueva = new Habitacion(); //Asignacion de formulario a campos

            nueva.Nhab = habitacion.Nhab;
            
            
            nueva.Camas = habitacion.Camas;
            nueva.Estado = habitacion.Estado;

            
            nueva.Garantia = habitacion.Garantia;
            nueva.Id = habitacion.Id;
            nueva.Precio = habitacion.Precio;
            

            await context.AddAsync(nueva);
            await context.SaveChangesAsync();
            return nueva.Id;
            //try
            //{
            //    var FiltrarPost = await context.Habitaciones.
            //    AnyAsync(c => c.Nhab.Equals(habitacion.Nhab));

            //    if (FiltrarPost)
            //    {
            //        return BadRequest($"Ya existe una habitacion con el numero {habitacion.Nhab} agregada ");
            //    }
            //    Habitacion nueva = new() //Asignacion de formulario a campos
            //    {
            //        Id = habitacion.Id,
            //        Nhab = habitacion.Nhab,
            //        Camas = habitacion.Camas,
            //        Estado = habitacion.Estado,
            //        Precio = habitacion.Precio,
            //        Garantia = habitacion.Garantia,
            //    };
            //    context.Add(nueva);
            //    await context.SaveChangesAsync();
            //    return Ok();
            //}
            //catch (Exception)
            //{

            //    return BadRequest($"No se pudo crear la habitacion ");

            //}




        }

        [HttpPut]

        public async Task<ActionResult> Put(Habitacion habitacion,int nrohab)
        {
            var existe = await context.Habitaciones.FirstOrDefaultAsync(c => c.Nhab==nrohab);

            if (existe is null)
            {
                return NotFound("No se encontro la habitacion para ser actualizada");
            }
            context.Update(habitacion);
            await context.SaveChangesAsync();
            return Ok(habitacion);
        }

        [HttpDelete]

        public async Task<ActionResult> Delete(int nrohab)
        {
            var habitacion = await context.Habitaciones.FirstOrDefaultAsync(c => c.Nhab==nrohab);

            if (habitacion is null)
            {
                return NotFound("No encontro la habitacion para ser borrada");
            }

            context.Remove(habitacion);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("AgregarMuchasHabitaciones")]

        public async Task<ActionResult> PostHabitaciones(List<Habitacion> habitaciones)
        {
            context.AddRange(habitaciones);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}