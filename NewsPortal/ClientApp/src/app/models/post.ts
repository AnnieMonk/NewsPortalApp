import { Account } from './account';

export class Post {
    PostId?: number;
    Title: string;
    PublishDate: Date;
    Content: string;
    AccountId: number;
    Account = Account;
}