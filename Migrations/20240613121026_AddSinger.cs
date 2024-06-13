using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSinger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into singer_table(SingerName) Values('fulano')");
            migrationBuilder.Sql("Insert into singer_table(SingerName) Values('ciclano')");
            migrationBuilder.Sql("Insert into singer_table(SingerName) Values('beltrano')");
            migrationBuilder.Sql("Insert into singer_table(SingerName) Values('meltrano')");
            migrationBuilder.Sql("Insert into singer_table(SingerName) Values('deltrano')");
            migrationBuilder.Sql("Insert into singer_table(SingerName) Values('neltrano')");
                    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from singer_table");

        }
    }
}
