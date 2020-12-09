export interface BookRecommendation {
  id: string;
  isbn: string;
  publishDate: Date;
  title: string;
  cover: string;
  numberOfPages: number;
  genreId: string;
  publisherId: string;
  booksUserIsCurrentlyReading: {
    id: string;
    bookId: string;
    userId: string;
    currentPage: number
  };
}




