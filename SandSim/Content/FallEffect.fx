Texture2D SpriteTexture;

sampler2D samp = sampler_state
{
    Texture = <SpriteTexture>;
};

float2 size;


struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};

const float4 white = float4(1, 1, 1, 1);

const float4 black = float4(0, 0, 0, 1);

bool exists(float4 color)
{
    return color.r != 0 || color.g != 0 || color.b != 0;
}

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float2 pos = float2(input.TextureCoordinates.x * size.x, input.TextureCoordinates.y * size.y);

    float2 uvpos = float2(pos.x / size.x, pos.y / size.y);

    float4 colors[3][3];

    for (uint i = 0; i < 3; i++)
    {
        for (uint j = 0; j < 3; j++)
        {
            colors[i][j] = tex2D(samp, float2((pos.x + i - 1) / size.x, (pos.y + j - 1) / size.y));
        }
    }
    
    

    if (pos.y >= size.y - 5)
    {
        return white;
    }

    
    if (exists(colors[1][1]))
    {
        if (exists(colors[1][2]) && exists(colors[0][2]) && exists(colors[2][2]))
            return colors[1][1];
    }
    else
    {
        if (exists(colors[1][0].r))
            return colors[1][0];


        if (exists(colors[0][0]) && exists(colors[0][1]) && exists(colors[1][2]))
            return colors[0][0];
        if (exists(colors[2][0]) && exists(colors[2][1]) && exists(colors[1][2]))
            return colors[2][0];
    }

    return black;

}

technique SpriteDrawing
{
    pass P0
    {
        PixelShader = compile ps_4_0 MainPS();
    }
};
