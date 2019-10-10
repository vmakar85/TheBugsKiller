package com.blogpost.mybinaryway;

import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.scenes.scene2d.ui.Skin;

public class TheBugsKiller extends Game {
    SpriteBatch batch;
    Texture img;
    static public Skin gameSkin;


    @Override
    public void create() {
        // подготовка наших ресурсов
        batch = new SpriteBatch();
        img = new Texture("badlogic.jpg"); // тутдолжен быть жук

        //это наши шкурки
        gameSkin = new Skin(Gdx.files.internal("skin/glassy-ui.json"));
        this.setScreen(new TitleScreen(this));

        // Load the sprite sheet as a Texture


    }

    @Override
    public void render() {
        super.render();
    }

    @Override
    public void dispose() {
        batch.dispose();
        img.dispose();
    }
}
