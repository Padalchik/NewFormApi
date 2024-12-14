
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebForm.Entity;

#nullable disable

namespace WebForm.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity<Candidate>(b =>
            {
                    b.Property(c => c.Id)
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property(c => c.FirstName)
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property(c => c.LastName)
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property(c => c.MiddleName)
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey(c => c.Id);

                    b.ToTable("Candidates");
                });
        }
    }
}
