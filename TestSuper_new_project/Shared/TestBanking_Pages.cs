using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Super_new_project.Shared;

namespace TestSuper_new_project
{
	[Collection("Super_new_project")]
	public class TestBanking_Pages
	{
		[Fact]
		public void ViewIsCreated()
		{
			using var ctx = new TestContext();
			ctx.JSInterop.Mode = JSRuntimeMode.Loose;
			var componentUnderTest = ctx.RenderComponent<Banking_Pages>();
			Assert.NotNull(componentUnderTest);
		}
	}
}
