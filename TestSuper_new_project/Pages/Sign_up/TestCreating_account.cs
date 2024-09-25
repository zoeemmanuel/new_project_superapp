using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages.Sign_up;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestCreating_account
	{
		[Fact]
		public void ViewIsCreated()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			ctx.Services.AddIgniteUIBlazor(
				typeof(IgbInputModule),
				typeof(IgbButtonModule),
				typeof(IgbRippleModule));
			var componentUnderTest = ctx.RenderComponent<Creating_account>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
