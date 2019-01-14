/// <reference path= "../app/person.ts" />
/// <reference path= "../typings/jasmine/jasmine.d.ts" />
// http://www.codeproject.com/Tips/1030700/Testing-Typescript-with-Jasmine-and-Chutzpah
describe("Person FullName", function () {
    var person;
    beforeEach(function () {
        person = new Person();
        person.setFirstName("Joe");
        person.setLastName("Smith");
    });
    it("should concatenate first and last names", function () {
        expect(person.getFullName()).toBe("Joe, Smith");
    });
    it("should concatenate first and last names - incorrect", function () {
        expect(person.getFullName()).not.toBe("Joe, Doe");
    });
    it("should concatenate lastname first", function () {
        expect(person.getFullName(true)).toBe("Smith, Joe");
    });
    it("should not concatinate firstname first", function () {
        expect(person.getFullName(true)).not.toBe("Joe, Smith");
    });
});
//# sourceMappingURL=personTest.js.map