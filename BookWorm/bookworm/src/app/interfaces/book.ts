export interface Book {
  id: string;
  isbn: string;
  publishDate: Date;
  title: string;
  cover: string;
  numberOfPages: number;
  author: string;
  publisherId: string;
  genreId: string;
  genre: string;
  publisher: string;
  booksUserIsCurrentlyReading: {
      id: string;
      bookId: string;
      userId: string;
      currentPage: number
  };
}
