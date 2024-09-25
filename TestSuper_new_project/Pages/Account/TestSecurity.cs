using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages.Account;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestSecurity
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
			var componentUnderTest = ctx.RenderComponent<Security>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
