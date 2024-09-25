using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Pages.Chat_Pages;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestNew_Convo_Group
	{
		[Fact]
		public void ViewIsCreated()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			ctx.Services.AddIgniteUIBlazor(
				typeof(IgbNavDrawerModule),
				typeof(IgbInputModule),
				typeof(IgbButtonModule),
				typeof(IgbRippleModule));
			var componentUnderTest = ctx.RenderComponent<New_Convo_Group>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
