﻿using Microsoft.EntityFrameworkCore;
using WebAppMerck.Modelos.Models.Entities;

namespace WebAppMerck.DataAccess.Data.DatabaseSeeding
{
    public class LocalidadSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Localidad>().HasData(
                new Localidad { Id = 1, IdProvincia = 1, NombreLocalidad = "25 de Mayo" },
                new Localidad { Id = 2, IdProvincia = 1, NombreLocalidad = "3 de febrero" },
                new Localidad { Id = 3, IdProvincia = 1, NombreLocalidad = "A. Alsina" },
                new Localidad { Id = 4, IdProvincia = 1, NombreLocalidad = "A. Gonzáles Cháves" },
                new Localidad { Id = 5, IdProvincia = 1, NombreLocalidad = "Aguas Verdes" },
                new Localidad { Id = 6, IdProvincia = 1, NombreLocalidad = "Alberti" },
                new Localidad { Id = 7, IdProvincia = 1, NombreLocalidad = "Arrecifes" },
                new Localidad { Id = 8, IdProvincia = 1, NombreLocalidad = "Ayacucho" },
                new Localidad { Id = 9, IdProvincia = 1, NombreLocalidad = "Azul" },
                new Localidad { Id = 10, IdProvincia = 1, NombreLocalidad = "Bahía Blanca" },
                new Localidad { Id = 11, IdProvincia = 1, NombreLocalidad = "Balcarce" },
                new Localidad { Id = 12, IdProvincia = 1, NombreLocalidad = "Baradero" },
                new Localidad { Id = 13, IdProvincia = 1, NombreLocalidad = "Benito Juárez" },
                new Localidad { Id = 14, IdProvincia = 1, NombreLocalidad = "Berisso" },
                new Localidad { Id = 15, IdProvincia = 1, NombreLocalidad = "Bolívar" },
                new Localidad { Id = 16, IdProvincia = 1, NombreLocalidad = "Bragado" },
                new Localidad { Id = 17, IdProvincia = 1, NombreLocalidad = "Brandsen" },
                new Localidad { Id = 18, IdProvincia = 1, NombreLocalidad = "Campana" },
                new Localidad { Id = 19, IdProvincia = 1, NombreLocalidad = "Cañuelas" },
                new Localidad { Id = 20, IdProvincia = 1, NombreLocalidad = "Capilla del Señor" },
                new Localidad { Id = 21, IdProvincia = 1, NombreLocalidad = "Capitán Sarmiento" },
                new Localidad { Id = 22, IdProvincia = 1, NombreLocalidad = "Carapachay" },
                new Localidad { Id = 23, IdProvincia = 1, NombreLocalidad = "Carhue" },
                new Localidad { Id = 24, IdProvincia = 1, NombreLocalidad = "Cariló" },
                new Localidad { Id = 25, IdProvincia = 1, NombreLocalidad = "Carlos Casares" },
                new Localidad { Id = 26, IdProvincia = 1, NombreLocalidad = "Carlos Tejedor" },
                new Localidad { Id = 27, IdProvincia = 1, NombreLocalidad = "Carmen de Areco" },
                new Localidad { Id = 28, IdProvincia = 1, NombreLocalidad = "Carmen de Patagones" },
                new Localidad { Id = 29, IdProvincia = 1, NombreLocalidad = "Castelli" },
                new Localidad { Id = 30, IdProvincia = 1, NombreLocalidad = "Chacabuco" },
                new Localidad { Id = 31, IdProvincia = 1, NombreLocalidad = "Chascomús" },
                new Localidad { Id = 32, IdProvincia = 1, NombreLocalidad = "Chivilcoy" },
                new Localidad { Id = 33, IdProvincia = 1, NombreLocalidad = "Colón" },
                new Localidad { Id = 34, IdProvincia = 1, NombreLocalidad = "Coronel Dorrego" },
                new Localidad { Id = 35, IdProvincia = 1, NombreLocalidad = "Coronel Pringles" },
                new Localidad { Id = 36, IdProvincia = 1, NombreLocalidad = "Coronel Rosales" },
                new Localidad { Id = 37, IdProvincia = 1, NombreLocalidad = "Coronel Suarez" },
                new Localidad { Id = 38, IdProvincia = 1, NombreLocalidad = "Costa Azul" },
                new Localidad { Id = 39, IdProvincia = 1, NombreLocalidad = "Costa Chica" },
                new Localidad { Id = 40, IdProvincia = 1, NombreLocalidad = "Costa del Este" },
                new Localidad { Id = 41, IdProvincia = 1, NombreLocalidad = "Costa Esmeralda" },
                new Localidad { Id = 42, IdProvincia = 1, NombreLocalidad = "Daireaux" },
                new Localidad { Id = 43, IdProvincia = 1, NombreLocalidad = "Darregueira" },
                new Localidad { Id = 44, IdProvincia = 1, NombreLocalidad = "Del Viso" },
                new Localidad { Id = 45, IdProvincia = 1, NombreLocalidad = "Dolores" },
                new Localidad { Id = 46, IdProvincia = 1, NombreLocalidad = "Don Torcuato" },
                new Localidad { Id = 47, IdProvincia = 1, NombreLocalidad = "Ensenada" },
                new Localidad { Id = 48, IdProvincia = 1, NombreLocalidad = "Escobar" },
                new Localidad { Id = 49, IdProvincia = 1, NombreLocalidad = "Exaltación de la Cruz" },
                new Localidad { Id = 50, IdProvincia = 1, NombreLocalidad = "Florentino Ameghino" },
                new Localidad { Id = 282, IdProvincia = 3, NombreLocalidad = "Agronomía" },
                new Localidad { Id = 283, IdProvincia = 3, NombreLocalidad = "Almagro" },
                new Localidad { Id = 284, IdProvincia = 3, NombreLocalidad = "Balvanera" },
                new Localidad { Id = 285, IdProvincia = 3, NombreLocalidad = "Barracas" },
                new Localidad { Id = 286, IdProvincia = 3, NombreLocalidad = "Belgrano" },
                new Localidad { Id = 287, IdProvincia = 3, NombreLocalidad = "Boca" },
                new Localidad { Id = 288, IdProvincia = 3, NombreLocalidad = "Boedo" },
                new Localidad { Id = 289, IdProvincia = 3, NombreLocalidad = "Caballito" },
                new Localidad { Id = 290, IdProvincia = 3, NombreLocalidad = "Chacarita" },
                new Localidad { Id = 291, IdProvincia = 3, NombreLocalidad = "Coghlan" },
                new Localidad { Id = 292, IdProvincia = 3, NombreLocalidad = "Colegiales" },
                new Localidad { Id = 293, IdProvincia = 3, NombreLocalidad = "Constitución" },
                new Localidad { Id = 294, IdProvincia = 3, NombreLocalidad = "Flores" },
                new Localidad { Id = 295, IdProvincia = 3, NombreLocalidad = "Floresta" },
                new Localidad { Id = 296, IdProvincia = 3, NombreLocalidad = "La Paternal" },
                new Localidad { Id = 297, IdProvincia = 3, NombreLocalidad = "Liniers" },
                new Localidad { Id = 298, IdProvincia = 3, NombreLocalidad = "Mataderos" },
                new Localidad { Id = 299, IdProvincia = 3, NombreLocalidad = "Monserrat" },
                new Localidad { Id = 300, IdProvincia = 3, NombreLocalidad = "Monte Castro" },
                new Localidad { Id = 301, IdProvincia = 3, NombreLocalidad = "Nueva Pompeya" },
                new Localidad { Id = 302, IdProvincia = 3, NombreLocalidad = "Núñez" },
                new Localidad { Id = 303, IdProvincia = 3, NombreLocalidad = "Palermo" },
                new Localidad { Id = 304, IdProvincia = 3, NombreLocalidad = "Parque Avellaneda" },
                new Localidad { Id = 305, IdProvincia = 3, NombreLocalidad = "Parque Chacabuco" },
                new Localidad { Id = 306, IdProvincia = 3, NombreLocalidad = "Parque Chas" },
                new Localidad { Id = 307, IdProvincia = 3, NombreLocalidad = "Parque Patricios" },
                new Localidad { Id = 308, IdProvincia = 3, NombreLocalidad = "Puerto Madero" },
                new Localidad { Id = 309, IdProvincia = 3, NombreLocalidad = "Recoleta" },
                new Localidad { Id = 310, IdProvincia = 3, NombreLocalidad = "Retiro" },
                new Localidad { Id = 311, IdProvincia = 3, NombreLocalidad = "Saavedra" },
                new Localidad { Id = 312, IdProvincia = 3, NombreLocalidad = "San Cristóbal" },
                new Localidad { Id = 313, IdProvincia = 3, NombreLocalidad = "San Nicolás" },
                new Localidad { Id = 314, IdProvincia = 3, NombreLocalidad = "San Telmo" },
                new Localidad { Id = 315, IdProvincia = 3, NombreLocalidad = "Vélez Sársfield" },
                new Localidad { Id = 316, IdProvincia = 3, NombreLocalidad = "Versalles" },
                new Localidad { Id = 317, IdProvincia = 3, NombreLocalidad = "Villa Crespo" },
                new Localidad { Id = 318, IdProvincia = 3, NombreLocalidad = "Villa del Parque" },
                new Localidad { Id = 319, IdProvincia = 3, NombreLocalidad = "Villa Devoto" },
                new Localidad { Id = 320, IdProvincia = 3, NombreLocalidad = "Villa Gral. Mitre" },
                new Localidad { Id = 321, IdProvincia = 3, NombreLocalidad = "Villa Lugano" },
                new Localidad { Id = 322, IdProvincia = 3, NombreLocalidad = "Villa Luro" },
                new Localidad { Id = 323, IdProvincia = 3, NombreLocalidad = "Villa Ortúzar" },
                new Localidad { Id = 324, IdProvincia = 3, NombreLocalidad = "Villa Pueyrredón" },
                new Localidad { Id = 325, IdProvincia = 3, NombreLocalidad = "Villa Real" },
                new Localidad { Id = 326, IdProvincia = 3, NombreLocalidad = "Villa Riachuelo" },
                new Localidad { Id = 327, IdProvincia = 3, NombreLocalidad = "Villa Santa Rita" },
                new Localidad { Id = 328, IdProvincia = 3, NombreLocalidad = "Villa Soldati" },
                new Localidad { Id = 329, IdProvincia = 3, NombreLocalidad = "Villa Urquiza" },
                new Localidad { Id = 330, IdProvincia = 4, NombreLocalidad = "Aconquija" },
                new Localidad { Id = 331, IdProvincia = 4, NombreLocalidad = "Ancasti" },
                new Localidad { Id = 332, IdProvincia = 4, NombreLocalidad = "Andalgalá" },
                new Localidad { Id = 333, IdProvincia = 4, NombreLocalidad = "Antofagasta" },
                new Localidad { Id = 334, IdProvincia = 4, NombreLocalidad = "Belén" },
                new Localidad { Id = 335, IdProvincia = 4, NombreLocalidad = "Capayán" },
                new Localidad { Id = 336, IdProvincia = 4, NombreLocalidad = "Capital" },
                new Localidad { Id = 337, IdProvincia = 4, NombreLocalidad = "4" },
                new Localidad { Id = 338, IdProvincia = 4, NombreLocalidad = "Corral Quemado" },
                new Localidad { Id = 339, IdProvincia = 4, NombreLocalidad = "El Alto" },
                new Localidad { Id = 340, IdProvincia = 4, NombreLocalidad = "El Rodeo" },
                new Localidad { Id = 341, IdProvincia = 4, NombreLocalidad = "F.Mamerto Esquiú" },
                new Localidad { Id = 342, IdProvincia = 4, NombreLocalidad = "Fiambalá" },
                new Localidad { Id = 343, IdProvincia = 4, NombreLocalidad = "Hualfín" },
                new Localidad { Id = 344, IdProvincia = 4, NombreLocalidad = "Huillapima" },
                new Localidad { Id = 345, IdProvincia = 4, NombreLocalidad = "Icaño" },
                new Localidad { Id = 346, IdProvincia = 4, NombreLocalidad = "La Puerta" },
                new Localidad { Id = 347, IdProvincia = 4, NombreLocalidad = "Las Juntas" },
                new Localidad { Id = 348, IdProvincia = 4, NombreLocalidad = "Londres" },
                new Localidad { Id = 381, IdProvincia = 5, NombreLocalidad = "Col. Elisa" },
                new Localidad { Id = 382, IdProvincia = 5, NombreLocalidad = "Col. Popular" },
                new Localidad { Id = 383, IdProvincia = 5, NombreLocalidad = "Colonias Unidas" },
                new Localidad { Id = 384, IdProvincia = 5, NombreLocalidad = "Concepción" },
                new Localidad { Id = 385, IdProvincia = 5, NombreLocalidad = "Corzuela" },
                new Localidad { Id = 386, IdProvincia = 5, NombreLocalidad = "Cote Lai" },
                new Localidad { Id = 387, IdProvincia = 5, NombreLocalidad = "El Sauzalito" },
                new Localidad { Id = 388, IdProvincia = 5, NombreLocalidad = "Enrique Urien" },
                new Localidad { Id = 389, IdProvincia = 5, NombreLocalidad = "Fontana" },
                new Localidad { Id = 390, IdProvincia = 5, NombreLocalidad = "Fte. Esperanza" },
                new Localidad { Id = 391, IdProvincia = 5, NombreLocalidad = "Gancedo" },
                new Localidad { Id = 392, IdProvincia = 5, NombreLocalidad = "Gral. Capdevila" },
                new Localidad { Id = 393, IdProvincia = 5, NombreLocalidad = "Gral. Pinero" },
                new Localidad { Id = 394, IdProvincia = 5, NombreLocalidad = "Gral. San Martín" },
                new Localidad { Id = 395, IdProvincia = 5, NombreLocalidad = "Gral. Vedia" },
                new Localidad { Id = 396, IdProvincia = 5, NombreLocalidad = "Hermoso Campo" },
                new Localidad { Id = 397, IdProvincia = 5, NombreLocalidad = "I. del Cerrito" },
                new Localidad { Id = 398, IdProvincia = 5, NombreLocalidad = "J.J. Castelli" },
                new Localidad { Id = 399, IdProvincia = 5, NombreLocalidad = "La Clotilde" },
                new Localidad { Id = 400, IdProvincia = 5, NombreLocalidad = "La Eduvigis" },
                new Localidad { Id = 401, IdProvincia = 5, NombreLocalidad = "La Escondida" },
                new Localidad { Id = 402, IdProvincia = 5, NombreLocalidad = "La Leonesa" },
                new Localidad { Id = 403, IdProvincia = 5, NombreLocalidad = "La Tigra" },
                new Localidad { Id = 404, IdProvincia = 5, NombreLocalidad = "La Verde" },
                new Localidad { Id = 453, IdProvincia = 6, NombreLocalidad = "Dolavón" },
                new Localidad { Id = 454, IdProvincia = 6, NombreLocalidad = "Dr. R. Rojas" },
                new Localidad { Id = 455, IdProvincia = 6, NombreLocalidad = "El Hoyo" },
                new Localidad { Id = 456, IdProvincia = 6, NombreLocalidad = "El Maitén" },
                new Localidad { Id = 457, IdProvincia = 6, NombreLocalidad = "Epuyén" },
                new Localidad { Id = 458, IdProvincia = 6, NombreLocalidad = "Esquel" },
                new Localidad { Id = 459, IdProvincia = 6, NombreLocalidad = "Facundo" },
                new Localidad { Id = 460, IdProvincia = 6, NombreLocalidad = "Gaimán" },
                new Localidad { Id = 461, IdProvincia = 6, NombreLocalidad = "Gan Gan" },
                new Localidad { Id = 462, IdProvincia = 6, NombreLocalidad = "Gastre" },
                new Localidad { Id = 463, IdProvincia = 6, NombreLocalidad = "Gdor. Costa" },
                new Localidad { Id = 464, IdProvincia = 6, NombreLocalidad = "Gualjaina" },
                new Localidad { Id = 465, IdProvincia = 6, NombreLocalidad = "J. de San Martín" },
                new Localidad { Id = 466, IdProvincia = 6, NombreLocalidad = "Lago Blanco" },
                new Localidad { Id = 467, IdProvincia = 6, NombreLocalidad = "Lago Puelo" },
                new Localidad { Id = 468, IdProvincia = 6, NombreLocalidad = "Lagunita Salada" },
                new Localidad { Id = 469, IdProvincia = 6, NombreLocalidad = "Las Plumas" },
                new Localidad { Id = 470, IdProvincia = 6, NombreLocalidad = "Los Altares" },
                new Localidad { Id = 504, IdProvincia = 7, NombreLocalidad = "Arias" },
                new Localidad { Id = 505, IdProvincia = 7, NombreLocalidad = "Arroyito" },
                new Localidad { Id = 506, IdProvincia = 7, NombreLocalidad = "Arroyo Algodon" },
                new Localidad { Id = 507, IdProvincia = 7, NombreLocalidad = "Arroyo Cabral" },
                new Localidad { Id = 508, IdProvincia = 7, NombreLocalidad = "Arroyo Los Patos" },
                new Localidad { Id = 509, IdProvincia = 7, NombreLocalidad = "Assunta" },
                new Localidad { Id = 510, IdProvincia = 7, NombreLocalidad = "Atahona" },
                new Localidad { Id = 511, IdProvincia = 7, NombreLocalidad = "Ausonia" },
                new Localidad { Id = 512, IdProvincia = 7, NombreLocalidad = "Avellaneda" },
                new Localidad { Id = 513, IdProvincia = 7, NombreLocalidad = "Ballesteros" },
                new Localidad { Id = 514, IdProvincia = 7, NombreLocalidad = "Ballesteros Sud" },
                new Localidad { Id = 515, IdProvincia = 7, NombreLocalidad = "Balnearia" },
                new Localidad { Id = 516, IdProvincia = 7, NombreLocalidad = "Bañado de Soto" },
                new Localidad { Id = 517, IdProvincia = 7, NombreLocalidad = "Bell Ville" },
                new Localidad { Id = 518, IdProvincia = 7, NombreLocalidad = "Bengolea" },
                new Localidad { Id = 519, IdProvincia = 7, NombreLocalidad = "Benjamin Gould" },
                new Localidad { Id = 520, IdProvincia = 7, NombreLocalidad = "Berrotaran" },
                new Localidad { Id = 521, IdProvincia = 7, NombreLocalidad = "Bialet Masse" },
                new Localidad { Id = 522, IdProvincia = 7, NombreLocalidad = "Bouwer" },
                new Localidad { Id = 523, IdProvincia = 7, NombreLocalidad = "Brinkmann" },
                new Localidad { Id = 524, IdProvincia = 7, NombreLocalidad = "Buchardo" },
                new Localidad { Id = 525, IdProvincia = 7, NombreLocalidad = "Bulnes" },
                new Localidad { Id = 526, IdProvincia = 7, NombreLocalidad = "Cabalango" },
                new Localidad { Id = 527, IdProvincia = 7, NombreLocalidad = "Calamuchita" },
                new Localidad { Id = 963, IdProvincia = 8, NombreLocalidad = "Saladas" },
                new Localidad { Id = 964, IdProvincia = 8, NombreLocalidad = "San Antonio" }
                );
        }
    }
}