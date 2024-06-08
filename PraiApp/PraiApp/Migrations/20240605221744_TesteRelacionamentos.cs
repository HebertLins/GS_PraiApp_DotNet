using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraiApp.Migrations
{
    /// <inheritdoc />
    public partial class TesteRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_ENDERECO",
                columns: table => new
                {
                    id_endereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    rua_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cidade_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    uf_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cep_endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ENDERECO", x => x.id_endereco);
                });

            migrationBuilder.CreateTable(
                name: "TBL_RESPONSAVEL",
                columns: table => new
                {
                    id_responsavel = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_responsavel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF_RESPONSAVEL = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_RESPONSAVEL", x => x.id_responsavel);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PRAIA",
                columns: table => new
                {
                    ID_PRAIA = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_PRAIA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESC_PRAIA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LIMPEZA_PRAIA = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ESTRUTURA_PRAIA = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    SINALIZACAO_PRAIA = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    MONITORAMENTO_PRAIA = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    POLUICAO_PRAIA = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CONSERVACAO_AMBIENTAL_PRAIA = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    TOTAL_PRAIA = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    EnderecoIdEndereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PRAIA", x => x.ID_PRAIA);
                    table.ForeignKey(
                        name: "FK_TBL_PRAIA_TBL_ENDERECO_EnderecoIdEndereco",
                        column: x => x.EnderecoIdEndereco,
                        principalTable: "TBL_ENDERECO",
                        principalColumn: "id_endereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ORGANIZACAO",
                columns: table => new
                {
                    ID_ORGANIZACAO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_ORGANIZACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESC_ORGANIZACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TP_ORGANIZACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ_ORGANIZACAO = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    IdEndereco = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdResponsavel = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ORGANIZACAO", x => x.ID_ORGANIZACAO);
                    table.ForeignKey(
                        name: "FK_TBL_ORGANIZACAO_TBL_ENDERECO_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "TBL_ENDERECO",
                        principalColumn: "id_endereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_ORGANIZACAO_TBL_RESPONSAVEL_IdResponsavel",
                        column: x => x.IdResponsavel,
                        principalTable: "TBL_RESPONSAVEL",
                        principalColumn: "id_responsavel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER",
                columns: table => new
                {
                    ID_USER = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_USER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL_USER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SENHA_USER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OrganizacaoIdOrganizacao = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USER", x => x.ID_USER);
                    table.ForeignKey(
                        name: "FK_TBL_USER_TBL_ORGANIZACAO_OrganizacaoIdOrganizacao",
                        column: x => x.OrganizacaoIdOrganizacao,
                        principalTable: "TBL_ORGANIZACAO",
                        principalColumn: "ID_ORGANIZACAO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_AVALIACAO",
                columns: table => new
                {
                    ID_AVALIACAO = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    LIMPEZA_AVALIACAO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ESTRUTURA_AVALIACAO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    SINALIZACAO_AVALIACAO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    MONITORAMENTO_AVALIACAO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    POLUICAO_AVALIACAO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CONSERVACAO_AMBIENTAL_AVALIACAO = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    UserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    PraiaIdPraia = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_AVALIACAO", x => x.ID_AVALIACAO);
                    table.ForeignKey(
                        name: "FK_TBL_AVALIACAO_TBL_PRAIA_PraiaIdPraia",
                        column: x => x.PraiaIdPraia,
                        principalTable: "TBL_PRAIA",
                        principalColumn: "ID_PRAIA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_AVALIACAO_TBL_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "TBL_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_AVALIACAO_PraiaIdPraia",
                table: "TBL_AVALIACAO",
                column: "PraiaIdPraia");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_AVALIACAO_UserId",
                table: "TBL_AVALIACAO",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ORGANIZACAO_IdEndereco",
                table: "TBL_ORGANIZACAO",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ORGANIZACAO_IdResponsavel",
                table: "TBL_ORGANIZACAO",
                column: "IdResponsavel");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PRAIA_EnderecoIdEndereco",
                table: "TBL_PRAIA",
                column: "EnderecoIdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USER_OrganizacaoIdOrganizacao",
                table: "TBL_USER",
                column: "OrganizacaoIdOrganizacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_AVALIACAO");

            migrationBuilder.DropTable(
                name: "TBL_PRAIA");

            migrationBuilder.DropTable(
                name: "TBL_USER");

            migrationBuilder.DropTable(
                name: "TBL_ORGANIZACAO");

            migrationBuilder.DropTable(
                name: "TBL_ENDERECO");

            migrationBuilder.DropTable(
                name: "TBL_RESPONSAVEL");
        }
    }
}
