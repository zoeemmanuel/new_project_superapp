using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages.Dashboard;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestSocial_Media
	{
		[Fact]
		public void ViewIsCreated()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			ctx.Services.AddIgniteUIBlazor(
				typeof(IgbNavDrawerModule),
				typeof(IgbButtonModule),
				typeof(IgbRippleModule));
			var componentUnderTest = ctx.RenderComponent<Social_Media>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
