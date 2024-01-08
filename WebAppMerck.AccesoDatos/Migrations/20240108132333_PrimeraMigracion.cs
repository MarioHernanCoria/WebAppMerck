using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAppMerck.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clinica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaYhora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProvincia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreClinica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    NombreProvincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinicas_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProvincia = table.Column<int>(type: "int", nullable: true),
                    NombreLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "Provincias",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Consultas",
                columns: new[] { "Id", "Clinica", "FechaYhora", "MotivoConsulta", "Url" },
                values: new object[,]
                {
                    { 1, "CEGYR Medicina Reproductiva", new DateTime(2024, 1, 8, 10, 23, 33, 370, DateTimeKind.Local).AddTicks(2304), "Edad y Reserva Ovarica", "https://ejemplo.com/" },
                    { 2, "Centro de Investigaciones en Medicina Reproductiva", new DateTime(2024, 1, 8, 10, 23, 33, 370, DateTimeKind.Local).AddTicks(2363), "Evaluación de Reserva Ovárica", "https://ejemplo2.com/" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "NombreProvincia" },
                values: new object[,]
                {
                    { 1, "Buenos Aires" },
                    { 2, "Buenos Aires-GBA" },
                    { 3, "Capital Federal" },
                    { 4, "Catamarca" },
                    { 5, "Chaco" },
                    { 6, "Chubut" },
                    { 7, "Córdoba" },
                    { 8, "Corrientes" },
                    { 9, "Entre Ríos" },
                    { 10, "Formosa" },
                    { 11, "Jujuy" },
                    { 12, "La Pampa" },
                    { 13, "La Rioja" },
                    { 14, "Mendoza" },
                    { 15, "Misiones" },
                    { 16, "Neuquén" },
                    { 17, "Río Negro" },
                    { 18, "Salta" },
                    { 19, "San Juan" },
                    { 20, "San Luis" },
                    { 21, "Santa Cruz" },
                    { 22, "Santa Fe" },
                    { 23, "Santiago del Estero" },
                    { 24, "Tierra del Fuego" },
                    { 25, "Tucumán" }
                });

            migrationBuilder.InsertData(
                table: "Clinicas",
                columns: new[] { "Id", "Direccion", "Latitud", "Longitud", "NombreClinica", "NombreProvincia", "ProvinciaId" },
                values: new object[,]
                {
                    { 1, "Viamonte 1432", -34.6007441, -58.387174100000003, "CEGYR Medicina Reproductiva", "Capital Federal", 3 },
                    { 2, "Humboldt 2263", -34.5806714, -58.4302438, "CER", "Catamarca", 4 },
                    { 3, "Av.Forest 1166", -34.578822199999998, -58.460096700000001, "Centro de Investigaciones en Medicina Reproductiva", "Chaco", 4 },
                    { 4, "Alvear 514", -34.7197709, -58.256260400000002, "Centro Gens", "Chubut", 5 },
                    { 5, "Marcelo T. de Alvear 2084", -34.597464299999999, -58.3971746, "Halitus Instituto Médico", "Capital Federal", 3 },
                    { 6, "Bulnes 1104", -34.598300000000002, -58.417900000000003, "Maternity Bank", "Capital Federal", 3 },
                    { 7, "Av. del Libertador 5962", -34.557099999999998, -58.447600000000001, "WeFIV", "Capital Federal", 3 }
                });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "IdProvincia", "NombreLocalidad" },
                values: new object[,]
                {
                    { 1, 1, "25 de Mayo" },
                    { 2, 1, "3 de febrero" },
                    { 3, 1, "A. Alsina" },
                    { 4, 1, "A. Gonzáles Cháves" },
                    { 5, 1, "Aguas Verdes" },
                    { 6, 1, "Alberti" },
                    { 7, 1, "Arrecifes" },
                    { 8, 1, "Ayacucho" },
                    { 9, 1, "Azul" },
                    { 10, 1, "Bahía Blanca" },
                    { 11, 1, "Balcarce" },
                    { 12, 1, "Baradero" },
                    { 13, 1, "Benito Juárez" },
                    { 14, 1, "Berisso" },
                    { 15, 1, "Bolívar" },
                    { 16, 1, "Bragado" },
                    { 17, 1, "Brandsen" },
                    { 18, 1, "Campana" },
                    { 19, 1, "Cañuelas" },
                    { 20, 1, "Capilla del Señor" },
                    { 21, 1, "Capitán Sarmiento" },
                    { 22, 1, "Carapachay" },
                    { 23, 1, "Carhue" },
                    { 24, 1, "Cariló" },
                    { 25, 1, "Carlos Casares" },
                    { 26, 1, "Carlos Tejedor" },
                    { 27, 1, "Carmen de Areco" },
                    { 28, 1, "Carmen de Patagones" },
                    { 29, 1, "Castelli" },
                    { 30, 1, "Chacabuco" },
                    { 31, 1, "Chascomús" },
                    { 32, 1, "Chivilcoy" },
                    { 33, 1, "Colón" },
                    { 34, 1, "Coronel Dorrego" },
                    { 35, 1, "Coronel Pringles" },
                    { 36, 1, "Coronel Rosales" },
                    { 37, 1, "Coronel Suarez" },
                    { 38, 1, "Costa Azul" },
                    { 39, 1, "Costa Chica" },
                    { 40, 1, "Costa del Este" },
                    { 41, 1, "Costa Esmeralda" },
                    { 42, 1, "Daireaux" },
                    { 43, 1, "Darregueira" },
                    { 44, 1, "Del Viso" },
                    { 45, 1, "Dolores" },
                    { 46, 1, "Don Torcuato" },
                    { 47, 1, "Ensenada" },
                    { 48, 1, "Escobar" },
                    { 49, 1, "Exaltación de la Cruz" },
                    { 50, 1, "Florentino Ameghino" },
                    { 282, 3, "Agronomía" },
                    { 283, 3, "Almagro" },
                    { 284, 3, "Balvanera" },
                    { 285, 3, "Barracas" },
                    { 286, 3, "Belgrano" },
                    { 287, 3, "Boca" },
                    { 288, 3, "Boedo" },
                    { 289, 3, "Caballito" },
                    { 290, 3, "Chacarita" },
                    { 291, 3, "Coghlan" },
                    { 292, 3, "Colegiales" },
                    { 293, 3, "Constitución" },
                    { 294, 3, "Flores" },
                    { 295, 3, "Floresta" },
                    { 296, 3, "La Paternal" },
                    { 297, 3, "Liniers" },
                    { 298, 3, "Mataderos" },
                    { 299, 3, "Monserrat" },
                    { 300, 3, "Monte Castro" },
                    { 301, 3, "Nueva Pompeya" },
                    { 302, 3, "Núñez" },
                    { 303, 3, "Palermo" },
                    { 304, 3, "Parque Avellaneda" },
                    { 305, 3, "Parque Chacabuco" },
                    { 306, 3, "Parque Chas" },
                    { 307, 3, "Parque Patricios" },
                    { 308, 3, "Puerto Madero" },
                    { 309, 3, "Recoleta" },
                    { 310, 3, "Retiro" },
                    { 311, 3, "Saavedra" },
                    { 312, 3, "San Cristóbal" },
                    { 313, 3, "San Nicolás" },
                    { 314, 3, "San Telmo" },
                    { 315, 3, "Vélez Sársfield" },
                    { 316, 3, "Versalles" },
                    { 317, 3, "Villa Crespo" },
                    { 318, 3, "Villa del Parque" },
                    { 319, 3, "Villa Devoto" },
                    { 320, 3, "Villa Gral. Mitre" },
                    { 321, 3, "Villa Lugano" },
                    { 322, 3, "Villa Luro" },
                    { 323, 3, "Villa Ortúzar" },
                    { 324, 3, "Villa Pueyrredón" },
                    { 325, 3, "Villa Real" },
                    { 326, 3, "Villa Riachuelo" },
                    { 327, 3, "Villa Santa Rita" },
                    { 328, 3, "Villa Soldati" },
                    { 329, 3, "Villa Urquiza" },
                    { 330, 4, "Aconquija" },
                    { 331, 4, "Ancasti" },
                    { 332, 4, "Andalgalá" },
                    { 333, 4, "Antofagasta" },
                    { 334, 4, "Belén" },
                    { 335, 4, "Capayán" },
                    { 336, 4, "Capital" },
                    { 337, 4, "4" },
                    { 338, 4, "Corral Quemado" },
                    { 339, 4, "El Alto" },
                    { 340, 4, "El Rodeo" },
                    { 341, 4, "F.Mamerto Esquiú" },
                    { 342, 4, "Fiambalá" },
                    { 343, 4, "Hualfín" },
                    { 344, 4, "Huillapima" },
                    { 345, 4, "Icaño" },
                    { 346, 4, "La Puerta" },
                    { 347, 4, "Las Juntas" },
                    { 348, 4, "Londres" },
                    { 381, 5, "Col. Elisa" },
                    { 382, 5, "Col. Popular" },
                    { 383, 5, "Colonias Unidas" },
                    { 384, 5, "Concepción" },
                    { 385, 5, "Corzuela" },
                    { 386, 5, "Cote Lai" },
                    { 387, 5, "El Sauzalito" },
                    { 388, 5, "Enrique Urien" },
                    { 389, 5, "Fontana" },
                    { 390, 5, "Fte. Esperanza" },
                    { 391, 5, "Gancedo" },
                    { 392, 5, "Gral. Capdevila" },
                    { 393, 5, "Gral. Pinero" },
                    { 394, 5, "Gral. San Martín" },
                    { 395, 5, "Gral. Vedia" },
                    { 396, 5, "Hermoso Campo" },
                    { 397, 5, "I. del Cerrito" },
                    { 398, 5, "J.J. Castelli" },
                    { 399, 5, "La Clotilde" },
                    { 400, 5, "La Eduvigis" },
                    { 401, 5, "La Escondida" },
                    { 402, 5, "La Leonesa" },
                    { 403, 5, "La Tigra" },
                    { 404, 5, "La Verde" },
                    { 453, 6, "Dolavón" },
                    { 454, 6, "Dr. R. Rojas" },
                    { 455, 6, "El Hoyo" },
                    { 456, 6, "El Maitén" },
                    { 457, 6, "Epuyén" },
                    { 458, 6, "Esquel" },
                    { 459, 6, "Facundo" },
                    { 460, 6, "Gaimán" },
                    { 461, 6, "Gan Gan" },
                    { 462, 6, "Gastre" },
                    { 463, 6, "Gdor. Costa" },
                    { 464, 6, "Gualjaina" },
                    { 465, 6, "J. de San Martín" },
                    { 466, 6, "Lago Blanco" },
                    { 467, 6, "Lago Puelo" },
                    { 468, 6, "Lagunita Salada" },
                    { 469, 6, "Las Plumas" },
                    { 470, 6, "Los Altares" },
                    { 504, 7, "Arias" },
                    { 505, 7, "Arroyito" },
                    { 506, 7, "Arroyo Algodon" },
                    { 507, 7, "Arroyo Cabral" },
                    { 508, 7, "Arroyo Los Patos" },
                    { 509, 7, "Assunta" },
                    { 510, 7, "Atahona" },
                    { 511, 7, "Ausonia" },
                    { 512, 7, "Avellaneda" },
                    { 513, 7, "Ballesteros" },
                    { 514, 7, "Ballesteros Sud" },
                    { 515, 7, "Balnearia" },
                    { 516, 7, "Bañado de Soto" },
                    { 517, 7, "Bell Ville" },
                    { 518, 7, "Bengolea" },
                    { 519, 7, "Benjamin Gould" },
                    { 520, 7, "Berrotaran" },
                    { 521, 7, "Bialet Masse" },
                    { 522, 7, "Bouwer" },
                    { 523, 7, "Brinkmann" },
                    { 524, 7, "Buchardo" },
                    { 525, 7, "Bulnes" },
                    { 526, 7, "Cabalango" },
                    { 527, 7, "Calamuchita" },
                    { 963, 8, "Saladas" },
                    { 964, 8, "San Antonio" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicas_ProvinciaId",
                table: "Clinicas",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_IdProvincia",
                table: "Localidades",
                column: "IdProvincia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
