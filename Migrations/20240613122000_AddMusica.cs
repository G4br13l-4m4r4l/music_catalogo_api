using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica1', 'Album1', 1)");
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica2', 'Album2', 2)");
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica3', 'Album3', 1)");
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica4', 'Album4', 3)");
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica5', 'Album5', 4)");
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica6', 'Album6', 5)");
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica7', 'Album7', 6)");
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica8', 'Album8', 2)");
            migrationBuilder.Sql("Insert into musica_table(MusicaName,Album,SingerId) Values('Musica9', 'Album9', 4)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from musica_table");
        }
    }
}
