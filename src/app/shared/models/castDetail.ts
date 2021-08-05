export interface CastDetail {
    id:          number;
    name:        string;
    gender:      string;
    tmdbUrl:     string;
    profilePath: string;
    character:   null;
    movies:      Movie[];
}

export interface Movie {
    id:      number;
    title:   string;
    postUrl: string;
    budget:  number;
}
