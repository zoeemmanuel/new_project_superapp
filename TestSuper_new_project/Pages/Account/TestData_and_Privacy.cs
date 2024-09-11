using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages.Account;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestData_and_Privacy
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
			var componentUnderTest = ctx.RenderComponent<Data_and_Privacy>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
