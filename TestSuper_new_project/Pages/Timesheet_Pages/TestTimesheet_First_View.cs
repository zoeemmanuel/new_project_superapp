using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages.Timesheet_Pages;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestTimesheet_First_View
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
			var componentUnderTest = ctx.RenderComponent<Timesheet_First_View>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
