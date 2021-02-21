
    declare global {
      interface Object {
        tryEmptyToNull(): null;
      }

      interface Number {
        thousandsSeperator(): String;
    }
  }
  Object.prototype.tryEmptyToNull = function(): any {
    return this === '' ? null : this ;
  };




Number.prototype.thousandsSeperator = function(): string {
    return Number(this).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',');
}


  export {};
