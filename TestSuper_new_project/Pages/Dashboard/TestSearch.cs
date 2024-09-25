using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages.Dashboard;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestSearch
	{
		[Fact]
		public void ViewIsCreated()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			ctx.Services.AddIgniteUIBlazor(
				typeof(IgbNavDrawerModule),
				typeof(IgbButtonModule),
				typeof(IgbRippleModule),
				typeof(IgbInputModule));
			var componentUnderTest = ctx.RenderComponent<Search>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
