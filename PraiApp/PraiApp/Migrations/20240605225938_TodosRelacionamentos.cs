using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiApp.Migrations
{
    /// <inheritdoc />
    public partial class TodosRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_AVALIACAO_TBL_PRAIA_PraiaIdPraia",
                table: "TBL_AVALIACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_AVALIACAO_TBL_USER_UserId",
                table: "TBL_AVALIACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_PRAIA_TBL_ENDERECO_EnderecoIdEndereco",
                table: "TBL_PRAIA");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_USER_TBL_ORGANIZACAO_OrganizacaoIdOrganizacao",
                table: "TBL_USER");

            migrationBuilder.RenameColumn(
                name: "OrganizacaoIdOrganizacao",
                table: "TBL_USER",
                newName: "IdOrganizacao");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_USER_OrganizacaoIdOrganizacao",
                table: "TBL_USER",
                newName: "IX_TBL_USER_IdOrganizacao");

            migrationBuilder.RenameColumn(
                name: "EnderecoIdEndereco",
                table: "TBL_PRAIA",
                newName: "IdEndereco");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_PRAIA_EnderecoIdEndereco",
                table: "TBL_PRAIA",
                newName: "IX_TBL_PRAIA_IdEndereco");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TBL_AVALIACAO",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "PraiaIdPraia",
                table: "TBL_AVALIACAO",
                newName: "IdPraia");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_AVALIACAO_UserId",
                table: "TBL_AVALIACAO",
                newName: "IX_TBL_AVALIACAO_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_AVALIACAO_PraiaIdPraia",
                table: "TBL_AVALIACAO",
                newName: "IX_TBL_AVALIACAO_IdPraia");

            migrationBuilder.AlterColumn<int>(
                name: "ID_AVALIACAO",
                table: "TBL_AVALIACAO",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_AVALIACAO_TBL_PRAIA_IdPraia",
                table: "TBL_AVALIACAO",
                column: "IdPraia",
                principalTable: "TBL_PRAIA",
                principalColumn: "ID_PRAIA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_AVALIACAO_TBL_USER_IdUser",
                table: "TBL_AVALIACAO",
                column: "IdUser",
                principalTable: "TBL_USER",
                principalColumn: "ID_USER",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_PRAIA_TBL_ENDERECO_IdEndereco",
                table: "TBL_PRAIA",
                column: "IdEndereco",
                principalTable: "TBL_ENDERECO",
                principalColumn: "id_endereco",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_USER_TBL_ORGANIZACAO_IdOrganizacao",
                table: "TBL_USER",
                column: "IdOrganizacao",
                principalTable: "TBL_ORGANIZACAO",
                principalColumn: "ID_ORGANIZACAO",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_AVALIACAO_TBL_PRAIA_IdPraia",
                table: "TBL_AVALIACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_AVALIACAO_TBL_USER_IdUser",
                table: "TBL_AVALIACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_PRAIA_TBL_ENDERECO_IdEndereco",
                table: "TBL_PRAIA");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_USER_TBL_ORGANIZACAO_IdOrganizacao",
                table: "TBL_USER");

            migrationBuilder.RenameColumn(
                name: "IdOrganizacao",
                table: "TBL_USER",
                newName: "OrganizacaoIdOrganizacao");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_USER_IdOrganizacao",
                table: "TBL_USER",
                newName: "IX_TBL_USER_OrganizacaoIdOrganizacao");

            migrationBuilder.RenameColumn(
                name: "IdEndereco",
                table: "TBL_PRAIA",
                newName: "EnderecoIdEndereco");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_PRAIA_IdEndereco",
                table: "TBL_PRAIA",
                newName: "IX_TBL_PRAIA_EnderecoIdEndereco");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "TBL_AVALIACAO",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdPraia",
                table: "TBL_AVALIACAO",
                newName: "PraiaIdPraia");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_AVALIACAO_IdUser",
                table: "TBL_AVALIACAO",
                newName: "IX_TBL_AVALIACAO_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TBL_AVALIACAO_IdPraia",
                table: "TBL_AVALIACAO",
                newName: "IX_TBL_AVALIACAO_PraiaIdPraia");

            migrationBuilder.AlterColumn<long>(
                name: "ID_AVALIACAO",
                table: "TBL_AVALIACAO",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_AVALIACAO_TBL_PRAIA_PraiaIdPraia",
                table: "TBL_AVALIACAO",
                column: "PraiaIdPraia",
                principalTable: "TBL_PRAIA",
                principalColumn: "ID_PRAIA",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_AVALIACAO_TBL_USER_UserId",
                table: "TBL_AVALIACAO",
                column: "UserId",
                principalTable: "TBL_USER",
                principalColumn: "ID_USER",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_PRAIA_TBL_ENDERECO_EnderecoIdEndereco",
                table: "TBL_PRAIA",
                column: "EnderecoIdEndereco",
                principalTable: "TBL_ENDERECO",
                principalColumn: "id_endereco",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_USER_TBL_ORGANIZACAO_OrganizacaoIdOrganizacao",
                table: "TBL_USER",
                column: "OrganizacaoIdOrganizacao",
                principalTable: "TBL_ORGANIZACAO",
                principalColumn: "ID_ORGANIZACAO",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
