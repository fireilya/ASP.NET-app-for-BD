create table health_phrases
(
    id         uuid not null,
    text       text not null,
    show_count int4 not null,
    CONSTRAINT "PK_health_phrases" PRIMARY KEY (id)
);