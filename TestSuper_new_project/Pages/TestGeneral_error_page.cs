using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestGeneral_error_page
	{
		[Fact]
		public void ViewIsCreated()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			ctx.Services.AddIgniteUIBlazor(
				typeof(IgbButtonModule),
				typeof(IgbRippleModule));
			var componentUnderTest = ctx.RenderComponent<General_error_page>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
