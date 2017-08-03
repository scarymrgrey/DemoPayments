import { NavMenu } from './nav-menu';

describe("NavMenu", () => {
  it("should be open by default", () => {
    expect(new NavMenu("Hello").isOpen).toBe(true);
  })
})
