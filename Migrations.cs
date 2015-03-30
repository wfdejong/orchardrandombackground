using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Indexing;


namespace Orchard.RandomBackground
{
	public class Migrations : DataMigrationImpl
	{

		public int Create()
		{
			SchemaBuilder.CreateTable("BackgroundPartRecord", table => table
				.ContentPartRecord()
			);

			return 1;
		}

		public int UpdateFrom1()
		{
			ContentDefinitionManager.AlterPartDefinition("BackgroundPart",
				builder => builder.WithField("BackgroundImage",
					fieldBuilder => fieldBuilder
						.OfType("MediaPickerField")
						.WithDisplayName("Background Image")));
			

			return 2;
		}

		public int UpdateFrom2()
		{
			ContentDefinitionManager.AlterTypeDefinition("Background", cfg => cfg			  
			  .WithPart("BackgroundPart")
			  .WithPart("CommonPart")
			  .Creatable()
			  .Indexed());

			return 3;
		}
	}
}