using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Infra.Configurations
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("TODO");

            builder.Property(t => t.Title)
                    .HasColumnType("varchar(150)")
                    .IsRequired()
                    .HasColumnName("TITLE");

            builder.Property(t => t.User)
                    .HasColumnType("varchar(150)")
                    .IsRequired()
                    .HasColumnName("USER");

            builder.Property(t => t.Date)
                    .IsRequired()
                    .HasColumnName("DATE");

            builder.Property(t => t.Done)
                    .HasColumnType("bit")
                    .HasColumnName("DONE");

        }

    }
}
