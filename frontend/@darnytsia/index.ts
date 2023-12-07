import { configure } from './bootstrap';
import { useLcz } from '@edenlabllc/sdk/hooks';
import { constants } from './db/consts';
import { EdlBook_FormPage } from "./ui/pages/books-form-page";
import {EdlBookAuthorsList_Page} from "./ui/pages/book-author-list-page";

export = {
  configure,
  db: {
    const: constants
  },
  lcz: useLcz,
  ui: {
    pages: {
        EdlBookAuthorsList_Page: EdlBookAuthorsList_Page,
      EdlBook_FormPage: EdlBook_FormPage,
    },
    details: {},
    sections: {}
  }
};
