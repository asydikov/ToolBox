export class User{
    email: string;
    name: string;
  constructor(email: string, name: string) {
    if (!email) {
      this.email = '';
    } else {
      this.email = email;
    }
    if (!name) {
      this.name = '';
    } else {
      this.name = name;
    }
    }
}
