shader_type canvas_item;

uniform vec2 offset = vec2(5.0, 5.0);
uniform vec4 shadow_color : source_color = vec4(0.0, 0.0, 0.0, 0.5);
uniform float blur_amount : hint_range(0.0, 5.0) = 1.0;

void fragment() {
    // Cor original do Sprite
    vec4 col = texture(TEXTURE, UV);
    
    // Cálculo da amostragem para a sombra (offset)
    // Dividimos o offset pelo tamanho da textura para manter a escala em pixels
    vec2 ps = TEXTURE_PIXEL_SIZE;
    vec2 shadow_uv = UV - (offset * ps);
    
    // Amostra o alpha da textura na posição deslocada
    float shadow_alpha = texture(TEXTURE, shadow_uv).a;
    
    // Se quiser um efeito de blur simples, podemos fazer múltiplas amostras 
    // ou apenas usar o alpha. Aqui aplicamos a cor da sombra:
    vec4 shadow = vec4(shadow_color.rgb, shadow_alpha * shadow_color.a);
    
    // Mistura: se o pixel original for transparente, mostra a sombra
    // Se o pixel original existir, ele fica por cima (Layering)
    COLOR = mix(shadow, col, col.a);
}