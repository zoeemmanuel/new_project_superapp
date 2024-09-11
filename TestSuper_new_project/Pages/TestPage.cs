using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestPage
	{
		[Fact]
		public void ViewIsCreated()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			var componentUnderTest = ctx.RenderComponent<Page>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
